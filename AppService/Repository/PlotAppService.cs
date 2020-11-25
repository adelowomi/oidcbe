using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Repository
{
    public class PlotAppService : ControllerBase, IPlotAppService
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
        public IEnumerable<PlotViewModel> GetByVendorId(int id)
        {
           return _plotService.GetPlotBy(id).Select(_mapper.Map<Plot, PlotViewModel>);
        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public IEnumerable<PlotViewModel> GetPlotById(int plotId)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetVendorByName(string name)
        {
            return Ok();
        }
    }
}
