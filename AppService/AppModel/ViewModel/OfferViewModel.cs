using System;
namespace AppService.AppModel.ViewModel
{
    public class OfferViewModel
    {
        public int PlotId { get; set; }

        public PlotViewModel Plot { get; set; }

        public string OfferStatus { get; set; }

        public string DocumentPath { get; set; }

        public bool IsPaymentCompleted { get; }
       
        public double AdministrativeFee { get; set; }

        public double LegalCharge { get; set; }

        public bool IsInstalmentalPayment { get; set; }

        public int InitialPaymentPercentage { get; set; }

        public int? PaymentCycleId { get; set; }

        public int PercentagePerCycle { get; set; }

        public int PaymentInNumberOfMonths { get; set; }
    }
}
