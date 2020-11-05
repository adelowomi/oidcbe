using System.IO;
using System.Threading.Tasks;
using AppService.Helpers;
using AppService.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AppService.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppSettings _setting;
        private readonly IHostingEnvironment _env;
        private readonly ISendGridClient _sendGridClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="env"></param>
        /// <param name="restEmailService"></param>
        public EmailService(IOptions<AppSettings> options, IHostingEnvironment env, ISendGridClient sendGridClient)
        {
            _setting = options.Value;
            _env = env;
            _sendGridClient = sendGridClient;
        }

        /// <summary>
        /// Send Email Via Rest API Service
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmail(string email, string subject, string message)
        {
            var sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress(_setting.SendGridSenderEmail),

                Subject = subject
            };

            sendGridMessage.AddTo(new EmailAddress(email));

            sendGridMessage.AddContent(MimeType.Html, message);

            await _sendGridClient.SendEmailAsync(sendGridMessage).ConfigureAwait(false);
        }

        /// <summary>
        /// This Method Helps Get The Email Template In Html
        /// </summary>
        /// <param name="env"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetEmailTemplate(IHostingEnvironment env, string name)
        {
            var emailTemplate = string.Empty;

            var emailFolder = Path.Combine(env.WebRootPath ?? env.ContentRootPath, "Templates");

            if (!Directory.Exists(emailFolder))
            {
                Directory.CreateDirectory(emailFolder);

            } else {
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