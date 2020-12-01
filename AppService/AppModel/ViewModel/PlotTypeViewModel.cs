using System;
namespace AppService.AppModel.ViewModel
{
    public class PlotTypeViewModel
    {
        public int PlotTypeId { get; set; }

        public string PlotTypeName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
