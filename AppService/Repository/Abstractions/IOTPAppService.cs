using System;
using System.Threading.Tasks;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public interface IOTPAppService
    {
        OTP ValidateOTP(int userId, string token);
    }
}
