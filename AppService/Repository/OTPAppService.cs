using System;
using AppService.Exceptions;
using AppService.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AppService.Repository
{
    public class OTPAppService : IOTPAppService
    {
        private readonly IOTPService _otpService;
        private readonly UserManager<AppUser> _userManager;

        public OTPAppService(IOTPService otpService, UserManager<AppUser> userManager)
        {
            _otpService = otpService;
            _userManager = userManager;
        }

        public OTP ValidateOTP(int userId, string token)
        {
            var code = _otpService.ConfirmToken(userId, token);

            if(code == null)
            {
                throw new InvalidTokenCodeExcepton(token);

            } else if (code.IsExpired){

                throw new ExpiredTokenCodeException(token);

            }

            var user = _userManager.FindByIdAsync(userId.ToString()).Result;

            user.EmailConfirmed = true;

            _ = _userManager.UpdateAsync(user).Result;

            return code;
        }
    }
}
