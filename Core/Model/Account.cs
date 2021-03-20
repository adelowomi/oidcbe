using System;
namespace Core.Model
{
    public class Account : BaseNameEntity
    {
        public string BankName { get; set; }

        public string Number { get; set; }
    }
}
