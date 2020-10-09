using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IUtilityAppService
    {
        GenderViewModel GenderById(int id);

        GenderViewModel GenderByName(string name);
    }
}
