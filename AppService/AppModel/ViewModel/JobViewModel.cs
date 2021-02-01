using System;
namespace AppService.AppModel.ViewModel
{
    public class JobViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int JobTypeId { get; set; }

        public string JobType { get; set; }

        public int JobStatusId { get; set; }

        public string JobStatus { get; set; }

        public int? AppUserId { get; set; }

        public VendorViewModel AppUser { get; set; }

        public string Address { get; set; }

        public string Document { get; set; }

        public DateTime ValidityPeriod { get; set; }
    }
}
