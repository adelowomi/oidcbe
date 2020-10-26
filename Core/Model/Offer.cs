using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Offer : BaseEntity
    {
        public int PlotId { get; set; }

        public Plot Plot { get; set; }

        public int? OfferStatusId { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public string DocumentPath { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        public bool IsPaymentCompleted { get; }
    }
}