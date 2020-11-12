using System;
using AppService.Exceptions;
using AppService.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AppService.Helpers;

namespace AppService.Repository
{
    public class OTPAppService : IOTPAppService
    {
        private readonly IOTPService _otpService;
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="otpService"></param>
        /// <param name="userManager"></param>
        public OTPAppService(IOTPService otpService, UserManager<AppUser> userManager)
        {
            _otpService = otpService;
            _userManager = userManager;
        }

        /// <summary>
        /// Concrete Method To Validate OTP
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public OTP ValidateOTP(int userId, string token, string platform)
        {
            var code = _otpService.ConfirmToken(userId, token, platform);

            if(code == null)
            {
                throw new InvalidTokenCodeExcepton(token);

            } else if (code.IsExpired){

                throw new ExpiredTokenCodeException(token);

            }

            if((platform ?? Res.WEB_PLATFORM).ToLower() == Res.MOBILE_PLATFORM)
            {
                var user = _userManager.FindByIdAsync(userId.ToString()).Result;

                user.EmailConfirmed = true;

                _ = _userManager.UpdateAsync(user).Result;

                return code;
            }

            return code;
        }
    }
}
