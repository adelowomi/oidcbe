using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _workOrderRepository;

        public WorkOrderService(IWorkOrderRepository workOrderRepository)
        {
            _workOrderRepository = workOrderRepository;
        }

        public WorkOrder CreateNew(WorkOrder workOrder)
        {
            return _workOrderRepository.CreateNewWorkOrder(workOrder);
        }

        public IEnumerable<WorkOrder> GetAlByUserId(int userId)
        {
            return _workOrderRepository.GetAllByUserId(userId);
        }

        public IEnumerable<WorkOrder> GetAll()
        {
            return _workOrderRepository.GetAllWorkOrders();
        }

        public IEnumerable<WorkOrder> GetAllBySubscriptionId(int subscriptionId)
        {
            return _workOrderRepository.GetAllBySubscriptionId(subscriptionId);
        }

        public WorkOrder GetById(int id)
        {
            return _workOrderRepository.GetById(id);
        }

        public WorkOrder GetByUserId(int userId)
        {
            return _workOrderRepository.GetByUserId(userId);
        }

        public IEnumerable<WorkOrderType> GetWorkOrderTypes()
        {
            return _workOrderRepository.GetWorkOrderTypes();
        }
    }
}
