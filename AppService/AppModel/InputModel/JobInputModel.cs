using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class JobInputModel
    {
        [Required]
        public int JobTypeId { get; set; }

        [JsonIgnore]
        public int JobStatusId { get; set; }

        public int? AppUserId { get; set; }

        public DateTime ValidityPeriod { get; set; }
    }
}
