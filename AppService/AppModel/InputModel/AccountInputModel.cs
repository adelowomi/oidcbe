using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class AccountInputModel
    {
        [Required]
        public string BankName { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string AccountNumber { get; set; }
    }
}
