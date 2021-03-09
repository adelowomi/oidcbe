using System;
namespace Core.Model
{
    public class PaymentAllocation : BaseEntity
    {
        public int AppUserId { get; set; }

      //  public AppUser AppUser { get; set; }

        public int PlotId { get; set; }

        public Plot Plot { get; set; }

        public double Amount { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentReceiptPath { get; set; }

        public string CompanyAccountNumber { get; set; }

        public string CompanyBankName { get; set; }

        public int? ConfirmedByAppUserId { get; set; }

        public AppUser ConfirmedByAppUser { get; set; }

        public bool IsConfirmed { get; set; }

        public int PaymentStatusId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
