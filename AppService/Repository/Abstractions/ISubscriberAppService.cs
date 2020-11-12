using System;
using System.Collections.Generic;
using AppService.AppModel.ViewModel;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public interface ISubscriberAppService
    {
        IEnumerable<VendorViewModel> GetAllExisting();
    }
}
