using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Get All Available Plots
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plot> AllAvailablePlots()
        {
            return _plotRepository.GetAllAvailablePlots();
        }

        /// <summary>
        /// Get All Plots In The System
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plot> AllPlots()
        {
            return _plotRepository.GetPlots();
        }

        public Plot GetPlot(int plotId)
        {
            return _plotRepository.GetPlots().FirstOrDefault(x => x.Id == plotId);
        }

        /// <summary>
        /// Get Plot By Subscriber Id
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        public IEnumerable<Plot> GetPlotBy(int subscriberId)
        {
            return _plotRepository.GetSubscriberPlots(subscriberId);
        }


        /// <summary>
        /// Get Plot By VendorId
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public IEnumerable<Plot> GetPlotBy(int subscriberId, int vendorId)
        {
            return _plotRepository.GetVendorPlots(vendorId);
        }

        /// <summary>
        /// Purchase Plot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Plot PurchasePlot(int id)
        {
            return _plotRepository.PurchasePlot(id);
        }
    }
}
