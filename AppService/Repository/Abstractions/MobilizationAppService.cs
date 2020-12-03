using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Repository.Abstractions
{
    public class MobilizationAppService :  ResponseViewModel, IMobilizationAppService
    {
        protected readonly IMobilizationService _mobilizationService;
        protected readonly IMapper _mapper;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MobilizationAppService(IMobilizationService mobilizationService,
                                      IMapper mapper,
                                      UserManager<AppUser> userManager,
                                      IHttpContextAccessor httpContextAccessor)
        {
            _mobilizationService = mobilizationService;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseViewModel> CreateNew(MobilizationInputModel model)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            model.AppUserId = user.Id;

            var mappedResult = _mobilizationService.CreateNew(_mapper.Map<MobilizationInputModel, Mobilization>(model));

            var result = _mapper.Map<Mobilization, MobilizationViewModel>(mappedResult);

            return Ok(result);
        }

        public ResponseViewModel GetAll()
        {
            var result = _mobilizationService.GetAllMobilization().Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return Ok(result);
        }

        public ResponseViewModel GetByPlot(int id)
        {
            var result = _mobilizationService
                            .GetMobilizationByPlot(id)
                                .Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return Ok(result);
        }

        public async Task<ResponseViewModel> GetByUserAsync()
        {
            AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            var result = _mobilizationService
                           .GetMobilizationByUser(currentUser.Id)
                               .Select(_mapper.Map<Mobilization, MobilizationViewModel>);

            return Ok(result);
        }

        public ResponseViewModel Update(MobilizationInputModel model)
        {
            var result = _mobilizationService.Update(_mapper.Map<MobilizationInputModel, Mobilization>(model));

            var mappedResult = _mapper.Map<Mobilization, MobilizationViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
