using System;
namespace AppService.AppModel.ViewModel
{
    public class WorkOrderViewModel
    {
        public string Name { get; set; }

        public int SubscriptionId { get; set; }

        public string WorkOrderType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
