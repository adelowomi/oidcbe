using System;
namespace Core.Model
{
    public class PaymentStatus : BaseEntity
    {
        public string Name { get; set; }
    }
}

enum PaymentStatusEnum
{
    APPROVED = 0,
    PENDING,
    FAILED,
    DECLINED
}