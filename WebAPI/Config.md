cd .. && cd home/documents/orangeisland && git pull && docker build -t orange . && docker stop oidc-be && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
git pull && docker build -t orange . && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
docker build -t orange . && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
npx localtunnel --port 8080 --print-requests


GO

ALTER TABLE [AspNetUsers] ADD [DepartmentId] int NULL DEFAULT NULL;

GO

CREATE INDEX [IX_AspNetUsers_DepartmentId] ON [AspNetUsers] ([DepartmentId]);

GO

ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;

GO