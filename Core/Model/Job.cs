using System;
namespace Core.Model
{
    public class Job : BaseNameEntity
    {
        public int JobTypeId { get; set; }

        public JobType JobType { get; set; }

        public int JobStatusId { get; set; }

        public JobStatus JobStatus { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public DateTime ValidityPeriod { get; set; }
    }
}
