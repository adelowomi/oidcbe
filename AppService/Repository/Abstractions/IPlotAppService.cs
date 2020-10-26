using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IPlotAppService
    {
        public PlotViewModel GetPlotById(int plotId);

        public PlotViewModel GetByVendorId(int id);
    }
}
