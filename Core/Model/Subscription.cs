using System;
namespace Core.Model
{
    public class Subscription : BaseEntity
    {
        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int? OfferId { get; set; }

        public Offer Offer { get; set; }

        public int? OrganizationTypeId { get; set; }

        public OrganizationType OrganizationType { get; set; }

        public int SubscriptionStatusId { get; set; }

        public SubscriptionStatus SubscriptionStatus { get; set; }
    }
}