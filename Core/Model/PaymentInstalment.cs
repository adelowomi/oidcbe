using System;
namespace Core.Model
{
    public class PaymentInstalment : BaseEntity
    {
        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        public string PaymentReference { get; set; }

        public string TransactionReference { get; set; }

        public int PaymentMethodId { get; set; }

        //public PaymentMethod PaymentMethod { get; set; }

        public double Amount { get; set; }

        public int PaymentStatusId { get; set; }

        //public PaymentStatus PaymentStatus { get; set; }

        public double? PenaltyCharge { get; set; }

        public double? InterestRate { get; set; }

        public DateTime PaymentDueDate { get; set; }
    }
}
