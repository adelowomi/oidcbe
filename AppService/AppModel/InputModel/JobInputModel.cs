using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppService.AppModel.InputModel
{
    public class JobInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int JobTypeId { get; set; }

        [Required]
        public string Description { get; set; }

        [JsonIgnore]
        public int JobStatusId { get; set; }

        [JsonIgnore]
        public int? AppUserId { get; set; }

        public string Address { get; set; }

        public string Document { get; set; }

        public DateTime ValidityPeriod { get; set; }
    }
}
