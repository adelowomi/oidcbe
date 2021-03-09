using System;
using System.Text;
using AppService.AutoMapper;
using AppService.Helpers;
using AppService.Repository;
using AppService.Repository.Abstractions;
using AppService.Services;
using AppService.Services.Abstractions;
using AppService.Validations;
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
using Microsoft.OpenApi.Models;
using SendGrid.Extensions.DependencyInjection;
using WebAPI.SignalR.Hub;

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

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                
            );

            services.AddMvcCore(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(_ => "Invalid value");
                options.Filters.Add(new ValidateModelAttribute());

            })
            .AddAuthorization()
            .AddNewtonsoftJson();

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

            services.AddTransient<IOTPRepository, OTPRepository>();
            services.AddTransient<IOTPService, OTPService>();
            services.AddTransient<IOTPAppService, OTPAppService>();

            services.AddTransient<IPlotRepository, PlotRepository>();
            services.AddTransient<IPlotService, PlotService>();
            services.AddTransient<IPlotAppService, PlotAppService>();

            services.AddTransient<ISubscriberRepository, SubscriberRepository>();
            services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddTransient<ISubscriberAppService, SubscriberAppService>();
            services.AddTransient<IVendorRepository, VendorRepository>();

            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentAppService, DocumentAppService>();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentAppService, PaymentAppService>();

            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<ISubscriptionAppService, SubscriptionAppService>();

            services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();
            services.AddTransient<IWorkOrderService, WorkOrderService>();
            services.AddTransient<IWorkOrderAppService, WorkOrderAppService>();

            services.AddTransient<ICalendarRepository, CalendarRepository>();
            services.AddTransient<ICalendarService, CalendarService>();
            services.AddTransient<ICalendarAppService, CalendarAppService>();

            services.AddTransient<IMobilizationRepository, MobilizationRepository>();
            services.AddTransient<IMobilizationService, MobilizationService>();
            services.AddTransient<IMobilizationAppService, MobilizationAppService>();

            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IRequestAppService, RequestAppService>();

            services.AddTransient<IVisitorRepository, VisitorRepository>();
            services.AddTransient<IPermitRepository, PermitRepository>();
            services.AddTransient<IPermitService, PermitService>();
            services.AddTransient<IPermitAppService, PermitAppService>();

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVisitorRepository, VisitorRepository>();

            services.AddTransient<IForumRepository, ForumRepository>();
            services.AddTransient<IForumAppService, ForumAppService>();

            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactAppService, ContactAppService>();
            services.AddTransient<INotificationAppService, NotificationAppService>();

            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMessageAppService, MessageAppService>();

            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IOfferAppService, OfferAppService>();

            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IJobAppService, JobAppService>();

            services.AddTransient<IProposalRepository, ProposalRepository>();
            services.AddTransient<IProposalAppService, ProposalAppService>();
            services.AddTransient<IDepartmentAppService, DepartmentAppService>();

            services.AddScoped<IQRCodeAppService, QRCodeAppService>();

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
                options.SwaggerDoc("help", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OIDC API",
                    Description = "OIDC Portal / App API Methods",
                    Contact = new OpenApiContact
                    {
                        Name = "Cousant Limited",
                        Email = "info@cousant.com",
                        Url = new Uri("https://www.oidc.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licensed To Cousant Limited",
                        Url = new Uri("https://www.cousant/privacy-policy")
                    }

                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
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
                options.AddPolicy("PlotPolicy", policy => policy.RequireRole("SuperAdmin", "Admin", "Vendor", "Subscriber"));
                //options.AddPolicy("Admin", policy => policy.RequireRole("Admin", "Vendor"));
                //options.AddPolicy("Vendor", policy => policy.RequireRole("Vendor"));
            });

            services.AddSendGrid(options => {

                options.ApiKey = appSettings.SendGridApiKey;
                
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
            }

            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");
            });
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
