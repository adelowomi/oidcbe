using System;
namespace Core.Model
{
    public class WorkOrder : BaseEntity
    {
        public string Name { get; set; }

        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int PlotId { get; set; }

        public Plot Plot { get; set; }

        public int WorkOrderTypeId { get; set; }

        public WorkOrderType WorkOrderType { get; set; }

        public string Document { get; set; }

        public string Description { get; set; }

        public int? WorkOrderStatusId { get; set; }

        public WorkOrderStatus WorkOrderStatus { get; set; }
    }
}
