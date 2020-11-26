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
    }
}
