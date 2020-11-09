using System;
using System.Collections.Generic;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IUtilityAppService
    {
        GenderViewModel GenderById(int id);

        GenderViewModel GenderByName(string name);

        IEnumerable<PaymentProviderViewModel> GetPaymentProviders();
    }
}
