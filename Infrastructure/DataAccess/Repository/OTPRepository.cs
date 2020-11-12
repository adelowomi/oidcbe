using System;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Concrete Implementation Of IOTPRepository
    /// </summary>
    public class OTPRepository : BaseRepository<OTP>, IOTPRepository
    {
        private static Random random = new Random();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public OTPRepository(AppDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Method To Generate OTP
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expiryInMinutes"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public OTP GenerateOTP(int userId, int expiryInMinutes, string platform)
        {
            var token = RandomNumber(4);

            var slug = RandomAlphaNumeric(12);

            var otp = CreateAndReturn(new OTP {
                AppUserId = userId,
                Code = platform == null ? token : platform.ToLower() == "web" ? slug : token,
                PlatformId = platform == null ? 2  : platform.ToLower() == "web" ? 1 : 2,
                CodeSlug = slug,
                IsExpired = false,
                ExpiryDateTime = DateTime.Now.AddMinutes(expiryInMinutes),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            });

            return otp;
        }

        /// <summary>
        /// Method To Confirm OTP Code
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public OTP ConfirmToken(int userId, string token, string platform)
        {

            if((platform ?? "Web").ToLower() == "web")
            {
                return ConfirmTokenSlug(token);
            }
                
            var code = GetAll().FirstOrDefault(x => x.AppUserId == userId && x.Code == token && x.IsExpired == false);

            var user = _context.Users.FirstOrDefault(x => x.Id == code.AppUserId);

            if (code != null) {
                if (DateTime.Now > code.ExpiryDateTime)
                {
                    code.IsExpired = true;
                    Update(code);
                    return code;
                } else
                {
                    code.IsUsed = true;
                    code.UsedDateTime = DateTime.Now;
                    user.EmailConfirmed = true;
                    _context.SaveChanges();
                    Update(code);
                    return code;
                }
            }

            return code;
        }

        /// <summary>
        /// This Method Confirms Confirmation Link Sent Via Web Channel
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public OTP ConfirmTokenSlug(string slug)
        {
            var code = GetAll().FirstOrDefault(x => x.CodeSlug == slug);

            if (code != null)
            {
                if (DateTime.Now > code.ExpiryDateTime)
                {
                    code.IsExpired = true;
                    Update(code);
                    return code;
                }
                else
                {
                    code.IsUsed = true;
                    code.UsedDateTime = DateTime.Now;
                    Update(code);
                    return code;
                }
            }

            return code;
        }

        /// <summary>
        /// Confirm OTP Code Method Overload
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public OTP ConfirmToken(int userId, OTP token, string platform)
        {
            return ConfirmToken(userId, token.Code, platform);
        }

        /// <summary>
        /// Utility Method To Generate Random Number
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Utility Method To Generate Random String For Web Confirmation Link
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomAlphaNumeric(int length)
        {
            const string chars = "abcdefghkmnopqrstuvABCDEFGHKMNOPWRSTUV";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public OTP GetToken(string code, string platform)
        {
            if((platform ?? "Web").ToLower() == "web")
            {
                return GetAll().FirstOrDefault(x => x.CodeSlug == code);
            }

            return GetAll().FirstOrDefault(x => x.Code == code); ;
        }
    }
}
