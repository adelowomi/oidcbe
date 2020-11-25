using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Plot : BaseEntity
    {
        public int PlotTypeId { get; set; }

        public PlotType PlotType { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double KilometerSquare { get; set; }

        public double Acres { get; set; }

        public double Longitude { get; set; }

        public double Lattitude { get; set; }

        public bool IsAvailable { get; set; }

        public double? Amount { get; set; }

        public bool HasAmount { get; set; }

        public bool IsPaymentComplete { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public int? PlotStatusId { get; set; }

        public PlotStatus PlotStatus { get; set; }
    }

    public enum PlotStatusEnum
    {
        APPROVED = 1,
        SUSPENDED,
    }
}
