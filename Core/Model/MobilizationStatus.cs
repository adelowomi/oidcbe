using System;
namespace Core.Model
{
    public class MobilizationStatus : BaseNameEntity
    {
        
    }

    public enum MobilizationStatusEnum
    {
        APPROVED = 1,
        PENDING,
        SUSPENDED,
        DECLINED
    }
}
