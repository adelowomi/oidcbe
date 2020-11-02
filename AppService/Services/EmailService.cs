using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace AppService.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _setting;
        private readonly IHostingEnvironment _env;

        public EmailService(IOptions<AppSettings> options, IHostingEnvironment env)
        {
            _setting = options.Value;
            _env = env;
        }

        public async Task SendEmail(string email, string subject, string message)
        {
            try {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = _setting.EmailConfiguration.Username,
                        Password = _setting.EmailConfiguration.Password
                    };

                    client.Credentials = new NetworkCredential(_setting.EmailConfiguration.Username, _setting.EmailConfiguration.Password);
                    client.Host = _setting.EmailConfiguration.SmtpServer;
                    client.Port = _setting.EmailConfiguration.Port;
                    client.Timeout = 100000000;
                    client.UseDefaultCredentials = true;

                    if (_env.IsProduction())
                    {
                        client.EnableSsl = true;
                        client.Port = 587;
                    }

                    //client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(email));
                        emailMessage.From = new MailAddress(_setting.EmailConfiguration.From);
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        client.Send(emailMessage);
                    }
                }
                await Task.CompletedTask;

            } catch (Exception e) {  

            }
        }
    }
}