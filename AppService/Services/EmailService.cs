using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Services.Abstractions;
using AppService.Services.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace AppService.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _setting;
        private readonly IHostingEnvironment _env;
        private readonly RestEmailService _restEmailService;

        public EmailService(IOptions<AppSettings> options, IHostingEnvironment env, RestEmailService restEmailService)
        {
            _setting = options.Value;
            _env = env;
            _restEmailService = restEmailService;
        }

        public async Task SendEmail(string email, string subject, string message)
        {
            await _restEmailService.SendEmail(new EmailRequest
            {
                from = new From
                {
                    email = "confirmation@pepisandbox.com",
                    name = "OIDC"
                },
                subject = subject,
                content = new List<Content>()
                {
                    new Content { type = "html", value = message },
                },
                personalizations = new List<Personalization>()
                {
                    new Personalization{ to = new List<To> { new To { email = email, name = "Osinnowo Emmanuel" } } }
                }
            });

        }

        public static string GetEmailTemplate(IHostingEnvironment env, string name)
        {
            var emailTemplate = string.Empty;

            var emailFolder = Path.Combine(env.WebRootPath ?? env.ContentRootPath, "Templates"); //ContentRootPath

            if (!Directory.Exists(emailFolder))
            {
                Directory.CreateDirectory(emailFolder);

            }
            else
            {
                var path = Path.Combine(emailFolder, name ?? "EmailTemplate.html");

                using (var templateFile = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(templateFile))
                    {
                        emailTemplate = reader.ReadToEnd();
                    }
                }
            }

            return emailTemplate;
        }
    }
}