using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class PaymentInputModel
    {
        [Required]
        public int SubscriptionId { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

        [Required]
        public int PaymentProviderId { get; set; }

        public double Amount { get; set; }
    }
}
