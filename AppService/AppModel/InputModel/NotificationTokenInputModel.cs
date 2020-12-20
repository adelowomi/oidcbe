using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class NotificationTokenInputModel
    {
        [Required]
        public string Token { get; set; }
    }
}
