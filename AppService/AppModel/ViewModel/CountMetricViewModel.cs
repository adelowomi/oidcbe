using System;
namespace AppService.AppModel.ViewModel
{
    public class CountMetricViewModel
    {
        public int ExistingSubscribers { get; set; }

        public int NewSubscribers { get; set; }

        public int ExistingVendors { get; set; }

        public int NewVendors { get; set; }
    }
}
