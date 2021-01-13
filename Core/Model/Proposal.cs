using System;
namespace Core.Model
{
    public class Proposal : BaseEntity
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int ProposalStatusId { get; set; }

        public ProposalStatus ProposalStatus { get; set; }
    }
}
