using System.Text;
using AppService.AutoMapper;
using AppService.Helpers;
using AppService.Repository;
using AppService.Repository.Abstractions;
using AppService.Services;
using AppService.Services.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly("WebAPI")));

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddMvcCore(options => { }).AddAuthorization();

          

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddSingleton(new MapperConfiguration(config => { config.AddProfile(new AppAutoMapperConfig(appSettings)); }).CreateMapper());

           
           services.AddIdentity<AppUser, Role>()
                  .AddEntityFrameworkStores <AppDbContext>()
                  .AddDefaultTokenProviders();

            //UserService Dependencies Injection Configurations
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            //Utility Dependencies Injection Configurations
            services.AddTransient<IUtilityRepository, UtilityRepository>();
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IUtilityAppService, UtilityAppService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Dependency Injection for StateRepository
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IStateAppService, StateAppService>();

            services.AddHttpContextAccessor();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("help", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Docs",
                    Version = "v1"
                });
            });

            services.AddAuthentication(x =>
            {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,
                      ValidateAudience = false
                  };
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PlotPolicy", policy => policy.RequireRole("Super Admin", "Admin", "Vendor"));
                //options.AddPolicy("Admin", policy => policy.RequireRole("Admin", "Vendor"));
                //options.AddPolicy("Vendor", policy => policy.RequireRole("Vendor"));
            });
                      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseDeveloperExceptionPage();
            } 
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

           // app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/help/swagger.json", "Orange Island API Endpoint");
            });
            
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
         
        }
    }
}
