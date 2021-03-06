using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IWorkOrderAppService
    {
        Task<ResponseViewModel> CreateNew(WorkOrderInputModel workOrder);

        WorkOrderViewModel GetById(int id);

        Task<WorkOrderViewModel> GetByUserId();

        IEnumerable<WorkOrderViewModel> GetAll();

        Task<IEnumerable<WorkOrderViewModel>> GetAllByUserId();

        IEnumerable<WorkOrderViewModel> GetWorkOrderByPlot(int subscriptionId);

        IEnumerable<WorkOrderTypeViewModel> GetWorkOrderTypes();

        ResponseViewModel Approve(int workOrderId);

        ResponseViewModel Decline(int workOrderId);
    }
}
