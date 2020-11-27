using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class WorkOrderAppService : IWorkOrderAppService
    {
        private readonly IWorkOrderService _workOrderService;
        private readonly IMapper _mapper;

        public WorkOrderAppService(IWorkOrderService workOrderService, IMapper mapper)
        {
            _workOrderService = workOrderService;
            _mapper = mapper;
        }

        public WorkOrderViewModel CreateNew(WorkOrderInputModel workOrder)
        {
           return _mapper.Map<WorkOrder, WorkOrderViewModel>(
               _workOrderService.CreateNew(
                   _mapper.Map<WorkOrderInputModel, WorkOrder>(workOrder)));
        }

        public IEnumerable<WorkOrderViewModel> GetAllByUserId(int userId)
        {
            return _workOrderService.GetAllByUserId(userId).Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public IEnumerable<WorkOrderViewModel> GetAll()
        {
            return _workOrderService.GetAll().Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public IEnumerable<WorkOrderViewModel> GetAllBySubscriptionId(int subscriptionId)
        {
            return _workOrderService.GetAllBySubscriptionId(subscriptionId).Select(_mapper.Map<WorkOrder, WorkOrderViewModel>);
        }

        public WorkOrderViewModel GetById(int id)
        {
            return _mapper.Map<WorkOrder, WorkOrderViewModel>(_workOrderService.GetById(id));
        }

        public WorkOrderViewModel GetByUserId(int userId)
        {
            return _mapper.Map<WorkOrder, WorkOrderViewModel>(_workOrderService.GetByUserId(userId));
        }

        public IEnumerable<WorkOrderTypeViewModel> GetWorkOrderTypes()
        {
            return _workOrderService.GetWorkOrderTypes().Select(_mapper.Map<WorkOrderType, WorkOrderTypeViewModel>);
        }
    }
}
