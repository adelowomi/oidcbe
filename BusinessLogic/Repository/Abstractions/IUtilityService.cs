using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IUtilityService
    {
        Gender GetGender(int id);

        Gender GetGender(string name);

        IEnumerable<PaymentProvider> GetPaymentProviders();
    }
}
