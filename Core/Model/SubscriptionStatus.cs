using System;
namespace Core.Model
{
    public class SubscriptionStatus : BaseEntity
    {
        public string Name { get; set; }
    }

    public enum SubscriptionStatusEnum
    {
        PENDING = 1,
        APPROVED,
        SUSPENDED,
        DECLINED
    }
}
