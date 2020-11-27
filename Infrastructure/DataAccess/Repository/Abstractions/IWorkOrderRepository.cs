using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IWorkOrderRepository
    {
        WorkOrder CreateNewWorkOrder(WorkOrder workOrder);

        WorkOrder GetById(int id);

        WorkOrder GetByUserId(int id);

        IEnumerable<WorkOrder> GetAllWorkOrders();

        IEnumerable<WorkOrder> GetAllByUserId(int userId);

        IEnumerable<WorkOrder> GetAllBySubscriptionId(int subscriptionId);

        IEnumerable<WorkOrderType> GetWorkOrderTypes();
    }
}
