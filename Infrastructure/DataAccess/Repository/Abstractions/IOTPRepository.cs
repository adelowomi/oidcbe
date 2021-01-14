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

        /// <summary>
        /// Get Token Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP GetToken(string token, string platform);

        /// <summary>
        /// Get Platform By Id
        /// Method Overloads +1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Platform GetPlatformBy(int id);

        /// <summary>
        /// Get Platform By Id, Name
        /// Method Overloads +2
        /// </summary>
        /// <param name="id"></param>
        /// <param name="platformName"></param>
        /// <returns></returns>
        Platform GetPlatformBy(int id, string platformName);
    }
}
