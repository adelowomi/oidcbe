using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class RequestInputModel
    {
        [Required]
        public string RequestName { get; set; }

        [Required]
        public int RequestTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
