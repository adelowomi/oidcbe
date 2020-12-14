using System;
namespace AppService.AppModel.ViewModel
{
    public class SubscriptionViewModel 
    {
        public int SubscriptionId  { get; set; }

        public string Status { get; set; }

        public OfferViewModel Offer { get; set; }

        public string OrganizationType { get; set; }

        public double Amount { get; set; }
    }
}
