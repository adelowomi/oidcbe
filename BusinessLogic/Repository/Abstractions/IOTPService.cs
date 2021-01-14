using System;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    /// <summary>
    /// Interface IOTPService
    /// </summary>
    public interface IOTPService
    {
        /// <summary>
        /// Abstract Interface Method To Generate OTP
        /// </summary>
        /// <param name="appUserId"></param>
        /// <param name="expirationInMunites"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        string GenerateCode(int appUserId, int expirationInMunites, string platform);

        /// <summary>
        /// Abstract Interface Method To Confirm OTP
        /// </summary>
        /// <param name="appUserId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP ConfirmToken(int appUserId, string token, string platform);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        OTP VerifyToken(string token, string platform);

        /// <summary>
        /// Get Platform By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Platform GetPlatformByIts(int id);

        /// <summary>
        /// Get Platform By Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="platformName"></param>
        /// <returns></returns>
        Platform GetPlatformByIts(int id, string platformName);
    }
}
