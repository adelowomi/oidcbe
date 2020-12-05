using System;
namespace AppService.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string UploadDrive { get; set; }

        public string DriveName { get; set; }

        public EmailConfiguration EmailConfiguration { get; set; }

        public string BaseUrl { get; set; }

        public int OtpExpirationInMinutes { get; set; }

        public string SendGridApiKey { get; set; }

        public string SendGridSenderEmail { get; set; }

        public string SendGridSenderName { get; set; }

        public WebApp WebApp { get; set; }

        public string FireBaseBucket { get; set; }
          
    }

    public class WebApp
    {
        public string BaseUrl { get; set; }

        public string Register { get ; set;}

        public string ResetPassword { get; set; }
    }

    public class EmailConfiguration
    {
        public string From { get; set; }

        public string SmtpServer { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
