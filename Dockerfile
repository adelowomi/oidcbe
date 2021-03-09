FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libgdiplus
RUN apt-get install -y libc6-dev 
RUN ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll

WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY AppService/*.csproj ./AppService/
COPY BusinessLogic/*.csproj ./BusinessLogic/
COPY Core/*.csproj ./Core/
COPY Infrastructure/*.csproj ./Infrastructure/ 
COPY WebAPI/*.csproj ./WebAPI/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY AppService/. ./AppService/
COPY BusinessLogic/. ./BusinessLogic/
COPY Core/. ./Core/ 
COPY Infrastructure/. ./Infrastructure/ 
COPY WebAPI/. ./WebAPI/ 
COPY WebAPI/Templates/. ./WebAPI/Templates
#
WORKDIR /app/WebAPI
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/WebAPI/out ./
ENTRYPOINT ["dotnet", "WebAPI.dll"]