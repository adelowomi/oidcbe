using System;
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
        Plot GetPlotBy(int subscriberId);
    }
}
