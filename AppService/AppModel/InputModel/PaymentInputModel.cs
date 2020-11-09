using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class PaymentInputModel
    {
        [Required]
        public int SubscriberId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int PlotId { get; set; }

        [Required]
        public string TrnxRef { get; set; }
    }
}
