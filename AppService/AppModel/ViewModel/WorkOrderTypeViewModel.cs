using System;
namespace AppService.AppModel.ViewModel
{
    public class WorkOrderTypeViewModel
    {
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsActive { get; set; }
    }
}
