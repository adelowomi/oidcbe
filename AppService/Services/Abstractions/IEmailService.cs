using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AppService.Services.Abstractions
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);

        string GetEmailTemplate(IHostingEnvironment env, string name);
    }
}
