using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IMobilizationAppService
    {
        IEnumerable<MobilizationViewModel> GetAll();

        IEnumerable<MobilizationViewModel> GetByPlot(int id);

        IEnumerable<MobilizationViewModel> GetByUser(int id);

        MobilizationViewModel CreateNew(MobilizationInputModel model);

        MobilizationViewModel Update(MobilizationInputModel model);
    }
}
