using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public IEnumerable<PlotViewModel> GetByVendorId(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PlotViewModel>> GetPlotByCurrentUserAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public IActionResult GetVendorByName(string name);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlotViewModel> GetPlots();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlotViewModel> GetAvailablePlots();
    }
}
