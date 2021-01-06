using System;
using Newtonsoft.Json;

namespace AppService.AppModel.InputModel
{
    public class OfferInputModel
    {
        public int PlotId { get; set; }

        [JsonIgnore]
        public int? OfferStatusId { get; set; }

        public string DocumentPath { get; set; }

        public bool IsPaymentCompleted { get; }
    }
}
