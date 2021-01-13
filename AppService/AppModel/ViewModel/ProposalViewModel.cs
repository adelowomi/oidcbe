using System;
namespace AppService.AppModel.ViewModel
{
    public class ProposalViewModel
    {
        public JobViewModel Job { get; set; }

        public int AppUserId { get; set; }

        public VendorViewModel AppUser { get; set; }

        public string ProposalStatus { get; set; }
    }
}
