using System;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class OTPService : IOTPService
    {
        private readonly IOTPRepository _otpRepository;

        public OTPService(IOTPRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public OTP ConfirmToken(int appUserId, string token)
        {
            var code = _otpRepository.ConfirmToken(appUserId, token);

            return code;
        }

        public string GenerateCode(int appUserId, int expirationInMunites)
        {
            var code  = _otpRepository.GenerateOTP(appUserId, expirationInMunites);

            return code.Code;
        }
    }
}
