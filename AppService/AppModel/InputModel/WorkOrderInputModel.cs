using System;
namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int SubscriptionId { get; set; }

        public int? AppUserId { get; set; }

        public int WorkOrderTypeId { get; set; }
    }
}
