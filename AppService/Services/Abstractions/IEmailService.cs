using System;
using System.Threading.Tasks;

namespace AppService.Services.Abstractions
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);
    }
}
