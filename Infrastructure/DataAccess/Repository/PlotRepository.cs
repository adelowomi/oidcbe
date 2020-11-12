using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Concrete Implementation Of IPlotRepository
    /// </summary>
    public class PlotRepository : BaseRepository<Plot>, IPlotRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PlotRepository(AppDbContext context) : base(context)
        {

        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Plot GetPlotById(int id)
        {
            return GetAll().FirstOrDefault();
        }

        /// <summary>
        /// Get All Plots In Enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plot> GetPlots()
        {
            return GetAll();
        }
    }
}
