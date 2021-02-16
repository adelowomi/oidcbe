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
            var result = _workOrderRepository.CreateNewWorkOrder(workOrder);

            return result;
        }

        public IEnumerable<WorkOrder> GetAllByUserId(int userId)
        {
            return _workOrderRepository.GetAllByUserId(userId);
        }

        public IEnumerable<WorkOrder> GetAll()
        {
            return _workOrderRepository.GetAllWorkOrders();
        }

        public IEnumerable<WorkOrder> GetAllByPlot(int plotId)
        {
            return _workOrderRepository.GetAllByPlotId(plotId);
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

        public WorkOrder Approve(int workOrderId)
        {
            var result = _workOrderRepository.Approve(workOrderId);

            return result;
        }

        public WorkOrder DisApprove(int workOrderId)
        {
            var result = _workOrderRepository.Decline(workOrderId);

            return result;
        }
    }
}
