using System;
using System.Threading.Tasks;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public interface IOTPAppService
    {
        /// <summary>
        /// Abstract Interface Method To Validate OTP
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP ValidateOTP(int userId, string token, string platform);
    }
}
