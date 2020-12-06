﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Repository
{
    public class PlotAppService : ResponseViewModel, IPlotAppService
    {
        private readonly IPlotService _plotService;
        private readonly IMapper _mapper;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plotService"></param>
        /// <param name="mapper"></param>
        public PlotAppService (IPlotService plotService, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager)
        {
            _plotService = plotService;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<PlotViewModel> GetAvailablePlots()
        {
            return _plotService.AllAvailablePlots().Select(_mapper.Map<Plot, PlotViewModel>);
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
        /// Get Plot By VendorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PlotViewModel>> GetPlotByCurrentUserAsync()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _plotService.GetPlotBy(currentUser.Id).Select(_mapper.Map<Plot, PlotViewModel>);
        }

        /// <summary>
        /// Get Plot By Its Id
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public PlotViewModel GetPlotById(int plotId)
        {
            return _mapper.Map<Plot, PlotViewModel>(_plotService.GetPlot(plotId));
        }

        public IEnumerable<PlotViewModel> GetPlots()
        {
            return _plotService.AllPlots().Select(_mapper.Map<Plot, PlotViewModel>);
        }

        public ResponseViewModel GetVendorByName(string name)
        {
            return Ok();
        }

        public ResponseViewModel CreatePlot(PlotInputModel plot)
        {
            var plotType = _plotService.GetAvailablePlotTypes().FirstOrDefault(x => x.Id == plot.PlotTypeId);

            if(plotType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT_TYPE, ResponseErrorCodeStatus.INVALID_PLOT_TYPE);
            }

            var mappedResult = _mapper.Map<PlotInputModel, Plot>(plot);

            var savedResult = _mapper.Map<Plot, PlotViewModel>(_plotService.CreateNew(mappedResult));

            return Ok(savedResult);
        }

        public PlotViewModel EditPlot(PlotInputModel plot)
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel GetPlotTypes()
        {
            var mappedResult = _plotService.GetAvailablePlotTypes().Select(_mapper.Map<PlotType, PlotTypeViewModel>);

            return Ok((mappedResult));
        }
    }
}
