using System;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;

        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }

        public Plot GetPlotBy(int subscriberId)
        {
            return _plotRepository.GetPlotById(subscriberId);
        }
    }
}
