using System;
namespace Core.Model
{
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }
    }
}

enum PaymentMethoEnum
{
    ONLINE = 1,
    DEPOSIT,
    TRANSFER
}