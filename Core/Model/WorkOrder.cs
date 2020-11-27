using System;
namespace Core.Model
{
    public class WorkOrder : BaseEntity
    {
        public string Name { get; set; }

        public int SubscriptionId { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public Subscription Subscription { get; set; }

        public int WorkOrderTypeId { get; set; }

        public WorkOrderType WorkOrderType { get; set; }
    }
}
