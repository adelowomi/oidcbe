using System;
namespace AppService.AppModel.ViewModel
{
    public class ForumSubscriptionViewModel : BaseViewModel
    {
        public int ForumId { get; set; }

        public string Forum { get; set; }

        public int AppUserId { get; set; }

        public VendorViewModel AppUser { get; set; }
    }
}
