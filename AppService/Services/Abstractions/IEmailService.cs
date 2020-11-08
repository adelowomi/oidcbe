using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AppService.Services.Abstractions
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);

        Task SendRequestTokenEmail(string email, string code, string platform);

        Task SendCompleteResetPassword(string email, string firstName);

        string GetEmailTemplate(IHostingEnvironment env, string name);
    }
}
