using System;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IOTPRepository
    {
        OTP GenerateOTP(int userId);
    }
}
