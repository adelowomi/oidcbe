using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IMobilizationAppService
    {
        ResponseViewModel GetAll();

        ResponseViewModel GetByPlot(int id);

        Task<ResponseViewModel> GetByUserAsync();

        Task<ResponseViewModel> CreateNew(MobilizationInputModel model);

        ResponseViewModel Update(MobilizationInputModel model);
    }
}
