using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IPermitAppService
    {
        ResponseViewModel GetPermits();

        ResponseViewModel GetVehicleTypes();

        Task<ResponseViewModel> CreatePermit(PermitInputModel model);

        Task<ResponseViewModel> GetPermitsBy();

        ResponseViewModel GetPermitsBy(int id);

        ResponseViewModel GetPermitTypes();

        ResponseViewModel GetPermitStatuses();

        ResponseViewModel PermitApprove(int id);

        ResponseViewModel PermitDecline(int id);

        ResponseViewModel PermitSuspend(int id);
    }
}
