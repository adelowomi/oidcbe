using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IWorkOrderAppService
    {
        Task<WorkOrderViewModel> CreateNew(WorkOrderInputModel workOrder);

        WorkOrderViewModel GetById(int id);

        Task<WorkOrderViewModel> GetByUserId();

        IEnumerable<WorkOrderViewModel> GetAll();

        Task<IEnumerable<WorkOrderViewModel>> GetAllByUserId();

        IEnumerable<WorkOrderViewModel> GetAllBySubscriptionId(int subscriptionId);

        IEnumerable<WorkOrderTypeViewModel> GetWorkOrderTypes();
    }
}
