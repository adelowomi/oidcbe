using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace BusinessLogic.Repository
{
    public class OTPService : IOTPService
    {
        private readonly IOTPRepository _otpRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="otpRepository"></param>
        public OTPService(IOTPRepository otpRepository)
        {
            _otpRepository = otpRepository;
        }

        /// <summary>
        /// Concrete Implementation Method To Confirm Token
        /// </summary>
        /// <param name="appUserId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public OTP ConfirmToken(int appUserId, string token, string platform)
        {
            var code = _otpRepository.ConfirmToken(appUserId, token, platform);

            return code;
        }

        /// <summary>
        /// Concrete Implementation Method To Generate Token
        /// </summary>
        /// <param name="appUserId"></param>
        /// <param name="expirationInMunites"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public string GenerateCode(int appUserId, int expirationInMunites, string platform)
        {
            var code  = _otpRepository.GenerateOTP(appUserId, expirationInMunites, platform);

            return code.Code;
        }

        public Platform GetPlatformByIts(int id)
        {
            return _otpRepository.GetPlatformBy(id);
        }

        public Platform GetPlatformByIts(int id, string platformName)
        {
            return _otpRepository.GetPlatformBy(id, platformName);
        }

        public OTP VerifyToken(string token, string platform)
        {
            return _otpRepository.GetToken(token, platform);
        }
    }
}
