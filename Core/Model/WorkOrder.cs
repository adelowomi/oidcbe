using System;
namespace Core.Model
{
    public class WorkOrder : BaseEntity
    {
        public int SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        public int WorkOrderTypeId { get; set; }

        public WorkOrderType WorkOrderType { get; set; }
    }
}
