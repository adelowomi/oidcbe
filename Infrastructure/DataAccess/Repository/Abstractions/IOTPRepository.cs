using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IOTPRepository
    {
        /// <summary>
        /// Abstract Interface Method To Generate OTP
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expiryInMinutes"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP GenerateOTP(int userId, int expiryInMinutes, string platform);

        /// <summary>
        /// Abstract Interface Method To Confirm Token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP ConfirmToken(int userId, string token, string platform);
    }
}
