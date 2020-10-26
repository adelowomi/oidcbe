using System;
namespace Core.Model
{
    public class Payment : BaseEntity
    {
        public double Amount { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        public double Balance { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public string PaymentReceiptPath { get; set; }

        public int PaymentProviderId { get; set; }

        public PaymentProvider PaymentProvider { get; set; }

        public int PaymentStatusId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public int OfferId { get; set; }

        public Offer Offer { get; set; }
    }
}