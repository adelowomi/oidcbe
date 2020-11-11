using System.Collections.Generic;
using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IPlotRepository
    {
        /// <summary>
        /// Abstract Interface Method To Get Plot By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Plot GetPlotById(int id);

        /// <summary>
        /// Abstract Interface Method To Get All Plots In IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<Plot> GetPlots();
    }
}
