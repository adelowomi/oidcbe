using System;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using Core.Model;

namespace AppService.Repository
{
    public class PlotAppService : IPlotAppService
    {
        private readonly IPlotService _plotService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plotService"></param>
        /// <param name="mapper"></param>
        public PlotAppService (IPlotService plotService, IMapper mapper)
        {
            _plotService = plotService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Plot By VendorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlotViewModel GetByVendorId(int id)
        {
            return _mapper.Map<Plot, PlotViewModel>(_plotService.GetPlotBy(id));
        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public PlotViewModel GetPlotById(int plotId)
        {
            throw new NotImplementedException();
        }
    }
}
