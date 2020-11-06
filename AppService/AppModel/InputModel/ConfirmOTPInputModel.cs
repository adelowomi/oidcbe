using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class ConfirmOTPInputModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
