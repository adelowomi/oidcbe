using System;
using System.Collections.Generic;
using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace BusinessLogic.Repository
{
    /// <summary>
    /// Interface IPlotService
    /// </summary>
    public interface IPlotService
    {
        /// <summary>
        /// Abstract Interface Method To Get Plot By Subscriber Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        IEnumerable<Plot> GetPlotBy(int subscriberId);

        /// <summary>
        /// Abstract Interface Method To Get Plot By Subscriber Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        Plot GetPlot(int plotId);

        /// <summary>
        /// Abstract Interface Method To Get Plot By Vendor Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        IEnumerable<Plot> GetPlotBy(int subscriberId, int vendorId);


        /// <summary>
        /// Abstract Interface Method To Get Plot By Vendor Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        Plot PurchasePlot(int id);


        /// <summary>
        /// Abstract Interface Method To Get Plot By Vendor Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        IEnumerable<Plot> AllAvailablePlots();

        /// <summary>
        /// Abstract Interface Method To Get Plot By Vendor Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        IEnumerable<Plot> AllPlots();

        /// <summary>
        /// Create New Plot
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        Plot CreateNew(Plot plot);

        /// <summary>
        /// Edit Plot
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        Plot EditPlot(Plot plot);

        /// <summary>
        /// Get available plot types
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        IEnumerable<PlotType> GetAvailablePlotTypes();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Plot GetByPlotId(int id);
    }
}
