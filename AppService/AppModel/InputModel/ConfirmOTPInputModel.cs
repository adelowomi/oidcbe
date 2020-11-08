using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class ConfirmOTPInputModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 4)]
        public string Code { get; set; }
    }
}
