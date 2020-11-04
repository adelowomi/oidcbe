using System;
namespace BusinessLogic.Repository.Abstractions
{
    public interface IOTPService
    {
        string GenerateCode(int appUserId);
    }
}
