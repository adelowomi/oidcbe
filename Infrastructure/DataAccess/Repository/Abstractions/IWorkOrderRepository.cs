using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IWorkOrderRepository
    {
        WorkOrder CreateNewWorkOrder(WorkOrder workOrder);

        IEnumerable<WorkOrder> GetWorkOrderBy(int subscriptionId);

        IEnumerable<WorkOrderType> GetWorkOrderTypes();
    }
}
