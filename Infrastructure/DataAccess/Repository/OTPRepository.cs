using System;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class OTPRepository : BaseRepository<OTP>, IOTPRepository
    {
        private static Random random = new Random();

        public OTPRepository(AppDbContext context) : base(context)
        {

        }

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

        public OTP ConfirmToken(int userId, string token, string platform)
        {

            if(platform.ToLower() == "web")
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

        public OTP ConfirmTokenSlug(string slug)
        {
            var code = GetAll().FirstOrDefault(x => x.CodeSlug == slug && x.IsExpired == false);

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

        public OTP ConfirmToken(int userId, OTP token, string platform)
        {
            return ConfirmToken(userId, token.Code, platform);
        }

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomAlphaNumeric(int length)
        {
            const string chars = "abcdefghkmnopqrstuvABCDEFGHKMNOPWRSTUV";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
