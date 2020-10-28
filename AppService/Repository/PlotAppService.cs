using System;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;

namespace AppService.Repository
{
    public class PlotAppService : IPlotAppService
    {

        /// <summary>
        /// Get Plot By VendorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlotViewModel GetByVendorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public PlotViewModel GetPlotById(int plotId)
        {
            throw new NotImplementedException();
        }
    }
}
