using System;
namespace Core.Model
{
    public class OfferStatus : BaseEntity
    {
        public string Name { get; set; }
    }
}

public enum OfferStatusEnum
{
    APPROVED,
    PENDING,
    DECLINED
}