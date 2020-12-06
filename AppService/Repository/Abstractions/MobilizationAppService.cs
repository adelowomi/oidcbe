using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AppService.Repository.Abstractions
{
    public class MobilizationAppService :  ResponseViewModel, IMobilizationAppService
    {
        protected readonly IMobilizationService _mobilizationService;
        protected readonly IPlotService _plotService;
        protected readonly IMapper _mapper;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSettings _setting;

        public MobilizationAppService(IMobilizationService mobilizationService,
                                      IMapper mapper,
                                      IPlotService plotService,
                                      IOptions<AppSettings> options,
                                      UserManager<AppUser> userManager,
                                      IHttpContextAccessor httpContextAccessor)
        {
            _mobilizationService = mobilizationService;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _setting = options.Value;
            _plotService = plotService;
        }

        public async Task<ResponseViewModel> CreateNew(MobilizationInputModel model)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            var query = _plotService.AllPlots().FirstOrDefault(x => x.Id == model.PlotId);

            if (query == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            model.AppUserId = user.Id;

            var uploadResult = await
                BaseContentServer
                .Build(ContentServerTypeEnum.FIREBASE, _setting)
                .UploadDocumentAsync(FileDocument.Create(model.Document, $"Mobilization", $"{user.GUID}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

            model.Document = uploadResult.Path;

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

        public ResponseViewModel Update(int id, MobilizationInputModel model)
        {
            var query = _plotService.AllPlots().FirstOrDefault(x => x.Id == model.PlotId);

            if (query == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var data = _mobilizationService.GetAllMobilization().FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_MOBILIZATION, ResponseErrorCodeStatus.INVALID_MOBILIZATION);
            }

            //TODO: Check the owner of the mobilization, to prevent other user from updating the record
            var entityMapped = _mapper.Map<MobilizationInputModel, Mobilization>(model); entityMapped.Id = data.Id;

            var result = _mobilizationService.Update(entityMapped);

            var mappedResult = _mapper.Map<Mobilization, MobilizationViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
