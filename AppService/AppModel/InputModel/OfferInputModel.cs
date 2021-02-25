using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class OfferInputModel
    {
        public int PlotId { get; set; }

        [JsonIgnore]
        public int? OfferStatusId { get; set; }

        [Required]
        public string DocumentPath { get; set; }

        [JsonIgnore]
        public bool IsPaymentCompleted { get; }

        [JsonIgnore]
        public int UserId { get; set; }

        [Required]
        public double InitialAmount { get; set; }

        public double SellingPrice { get; set; }

        [Required]
        public double AdministrativeFee { get; set; }

        [Required]
        public double LegalCharge { get; set; }

        [Required]
        public bool IsInstalmentalPayment { get; set; }

        [Required]
        public int InitialPaymentPercentage { get; set; }

        [Required]
        public int? PaymentCycleId { get; set; }

        [Required]
        public int PercentagePerCycle { get; set; }

        [Required]
        public int PaymentInNumberOfMonths { get; set; }

        [Required]
        public int PaymentInNumberOfCycle { get; set; }

        [Required]
        public bool IsPrimarySale { get; set; }

        [Required]
        public bool IsSecondarySale { get; set; }

        [Required]
        public double PricePerSquareMeter { get; set; }
    }
}
