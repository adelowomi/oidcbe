using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IContactAppService
    {
        ResponseViewModel GetContacts();

        ResponseViewModel CreateContact(ContactInputModel contact);
    }
}
