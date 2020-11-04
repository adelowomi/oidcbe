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

        public string PepipostBaseUrl { get; set; }

        public string PepipostApiKey { get; set; }
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
