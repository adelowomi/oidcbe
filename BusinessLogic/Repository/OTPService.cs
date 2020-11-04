using System;
using BusinessLogic.Repository.Abstractions;
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

        public string GenerateCode(int appUserId)
        {
            var code  = _otpRepository.GenerateOTP(appUserId);

            return code.Code;
        }
    }
}
