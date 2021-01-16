using System;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class OfferInputModel
    {
        public int PlotId { get; set; }

        [JsonIgnore]
        public int? OfferStatusId { get; set; }

        public string DocumentPath { get; set; }

        public bool IsPaymentCompleted { get; }

        public int UserId { get; set; }

        public double InitialAmount { get; set; }

        public double SellingPrice { get; set; }

        public int DurationInMonths { get; set; }
    }
}
