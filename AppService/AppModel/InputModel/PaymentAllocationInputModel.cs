using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class PaymentAllocationInputModel
    {
        [Required]
        public int PlotId { get; set; }

        [Required]
        public string Receipt { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

        public string Note { get; set; }
    }
}
