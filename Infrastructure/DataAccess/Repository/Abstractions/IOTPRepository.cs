using System;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IOTPRepository
    {
        OTP GenerateOTP(int userId, int expiryInMinutes, string platform);

        OTP ConfirmToken(int userId, string token);
    }
}
