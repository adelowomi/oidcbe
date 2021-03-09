using System;
namespace AppService.AppModel.ViewModel
{
    public class PaymentAllocationViewModel
    {
        public int PlotId { get; set; }

        public PlotViewModel Plot { get; set; }

        public double Amount { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentTypeViewModel PaymentType { get; set; }

        public int PaymentMethodId { get; set; }

        public PaymentMethodViewModel PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentReceiptPath { get; set; }

        public string CompanyAccountNumber { get; set; }

        public string CompanyBankName { get; set; }

        public int? ConfirmedByAppUserId { get; set; }

        public VendorViewModel ConfirmedByAppUser { get; set; }

        public bool IsConfirmed { get; set; }

        public int PaymentStatusId { get; set; }

        public PaymentStatusViewModel PaymentStatus { get; set; }
    }
}
