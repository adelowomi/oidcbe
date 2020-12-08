using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AppService.Repository
{
    public class WorkOrderAppService : ResponseViewModel, IWorkOrderAppService
    {
        private readonly IWorkOrderService _workOrderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlotService _plotService;
        protected readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;

        public WorkOrderAppService(IWorkOrderService workOrderService,
                                    UserManager<AppUser> userManager,
                                    IMapper mapper,
                                    IOptions<AppSettings> options,
                                    IPlotService plotService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _workOrderService = workOrderService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _settings = options.Value;
            _plotService = plotService;
        }

        public async Task<ResponseViewModel> CreateNew(WorkOrderInputModel workOrder)
        {
            AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            //var uploadResult = await
            //    BaseContentServer
            //    .Build(ContentServerTypeEnum.FIREBASE, _settings)
            //    .UploadDocumentAsync(FileDocument.Create(workOrder.Document, $"WorkOrder", $"{currentUser.GUID}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

            var plotResult = _plotService.AllPlots().FirstOrDefault(x => x.Id == workOrder.PlotId);

            if(plotResult == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var workOrderType = _workOrderService.GetWorkOrderTypes().FirstOrDefault(x => x.Id == workOrder.WorkOrderTypeId);

            if(workOrderType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_WORK_ORDER_TYPE, ResponseErrorCodeStatus.INVALID_WORK_ORDER_TYPE);
            }

            workOrder.AppUserId = currentUser.Id;

           // workOrder.Document = uploadResult.Path;

            var result = _workOrderService.CreateNew(_mapper.Map<WorkOrderInputModel, WorkOrder>(workOrder));

            return Ok(_mapper.Map<WorkOrder, WorkOrderViewModel>(result));
        }

        public async Task<IEnumerable<WorkOrderViewModel>> GetAllByUserId()
        {
            AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _workOrderService.GetAllByUserId(currentUser.Id).Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public IEnumerable<WorkOrderViewModel> GetAll()
        {
            return _workOrderService.GetAll().Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public IEnumerable<WorkOrderViewModel> GetWorkOrderByPlot(int plotId)
        {
            return _workOrderService.GetAllByPlot(plotId).Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public WorkOrderViewModel GetById(int id)
        {
            return _mapper.Map<WorkOrder, WorkOrderViewModel>(_workOrderService.GetById(id));
        }

        public async Task<WorkOrderViewModel> GetByUserId()
        {
            AppUser currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _mapper.Map<WorkOrder, WorkOrderViewModel>(_workOrderService.GetByUserId(currentUser.Id));
        }

        public IEnumerable<WorkOrderTypeViewModel> GetWorkOrderTypes()
        {
            return _workOrderService.GetWorkOrderTypes().Select(_mapper.Map<WorkOrderType, WorkOrderTypeViewModel>);
        }

    }
}
