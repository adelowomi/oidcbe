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

        public OTP GenerateOTP(int userId, int expiryInMinutes)
        {
            var token = RandomNumber(4);

            //var count = GetAll().Count(x => x.AppUserId == userId && x.Code == token);

            //while(count == 0)
            //{
                
            //}

            var otp = CreateAndReturn(new OTP {
                AppUserId = userId,
                Code = token,
                IsExpired = false,
                ExpiryDateTime = DateTime.Now.AddMinutes(expiryInMinutes),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            });

            return otp;
        }

        public OTP ConfirmToken(int userId, string token)
        {
            var code = GetAll().FirstOrDefault(x => x.AppUserId == userId && x.Code == token && x.IsExpired == false);

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
                    Update(code);
                    return code;
                }
            }

            return code;
        }

        public OTP ConfirmToken(int userId, OTP token)
        {
            return ConfirmToken(userId, token.Code);
        }

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
