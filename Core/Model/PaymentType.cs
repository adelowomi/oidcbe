using System;
namespace Core.Model
{
    public class PaymentType : BaseEntity
    {
        public string Name { get; set; }
    }
}

enum PaymentType
{
    FULL,
    PART
}