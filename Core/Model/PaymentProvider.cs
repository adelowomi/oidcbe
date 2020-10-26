using System;
namespace Core.Model
{
    public class PaymentProvider : BaseEntity
    {
        public string Name { get; set; }

    }
}

enum PaymentProviderEnum
{
    PAYSTACK = 1,
    FLUTTERWAVE,
    INTERSWITCH
}