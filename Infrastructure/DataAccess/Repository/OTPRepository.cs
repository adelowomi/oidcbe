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

        public OTP GenerateOTP(int userId)
        {
            var token = RandomNumber(4);
            var otp =  CreateAndReturn(new OTP { AppUserId = userId, Code = token , DateCreated = DateTime.Now, DateModified = DateTime.Now });
            return otp;
        }

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
