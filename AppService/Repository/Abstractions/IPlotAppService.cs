using System;
using AppService.AppModel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Repository.Abstractions
{
    /// <summary>
    /// IPlotAppService Interface
    /// </summary>
    public interface IPlotAppService
    {
        /// <summary>
        /// Abstract Interface Method To Get Plot By Id
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public PlotViewModel GetPlotById(int plotId);

        /// <summary>
        /// Abstract Interface Method To Get Plot By Its Vendor Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlotViewModel GetByVendorId(int id);

        public IActionResult GetVendorByName(string name);
    }
}
