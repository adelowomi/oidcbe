using System;
namespace AppService.AppModel.ViewModel
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string PaymentType { get; set; }

        public double Balance { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentReceiptPath { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentStatus { get; set; }

        public SubscriptionViewModel Subscription { get; set; }

        public string TrnxRef { get; set; }

        public int AppUserId { get; set; }

        public int PlotId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string QRCodeCodeLink { get; set; }
    }
}
