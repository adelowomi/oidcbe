using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IWorkOrderAppService
    {
        WorkOrderViewModel CreateNew(WorkOrderInputModel workOrder);

        WorkOrderViewModel GetById(int id);

        WorkOrderViewModel GetByUserId(int userId);

        IEnumerable<WorkOrderViewModel> GetAll();

        IEnumerable<WorkOrderViewModel> GetAllByUserId(int userId);

        IEnumerable<WorkOrderViewModel> GetAllBySubscriptionId(int subscriptionId);

        IEnumerable<WorkOrderTypeViewModel> GetWorkOrderTypes();
    }
}
