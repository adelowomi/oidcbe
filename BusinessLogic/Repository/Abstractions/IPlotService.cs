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
    }
}
