using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IWorkOrderService
    {
        WorkOrder CreateNew(WorkOrder workOrder);

        WorkOrder GetById(int id);

        WorkOrder GetByUserId(int userId);

        IEnumerable<WorkOrder> GetAll();

        IEnumerable<WorkOrder> GetAllByUserId(int userId);

        IEnumerable<WorkOrder> GetAllByPlot(int subscriptionId);

        IEnumerable<WorkOrderType> GetWorkOrderTypes();

        WorkOrder Approve(int workOrderId);

        WorkOrder DisApprove(int workOrderId);
    }
}
