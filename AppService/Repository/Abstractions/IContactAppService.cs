using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IContactAppService
    {
        ResponseViewModel GetContacts();
    }
}
