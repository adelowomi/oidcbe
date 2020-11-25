using System;
namespace AppService.AppModel.ViewModel
{
    public class OfferViewModel
    {
        public int PlotId { get; set; }

        public string PlotName { get; set; }

        public int? OfferStatusId { get; set; }

        public string DocumentPath { get; set; }

        public bool IsPaymentCompleted { get; }
    }
}
