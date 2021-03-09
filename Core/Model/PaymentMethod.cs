using System;
namespace Core.Model
{
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }
    }
}

public enum PaymentMethoEnum
{
    ONLINE = 1,
    DEPOSIT,
    TRANSFER
}