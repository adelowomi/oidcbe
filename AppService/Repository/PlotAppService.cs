using System;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;

namespace AppService.Repository
{
    public class PlotAppService : IPlotAppService
    {
        public PlotViewModel GetByVendorId(int id)
        {
            throw new NotImplementedException();
        }

        public PlotViewModel GetPlotById(int plotId)
        {
            throw new NotImplementedException();
        }
    }
}
