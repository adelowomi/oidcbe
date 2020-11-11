using System;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace BusinessLogic.Repository
{
    /// <summary>
    /// Concrete Implementation Of IPlotService Interface
    /// </summary>
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plotRepository"></param>
        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        /// <summary>
        /// Get Plot By Subscriber Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        public Plot GetPlotBy(int subscriberId)
        {
            return _plotRepository.GetPlotById(subscriberId);
        }
    }
}
