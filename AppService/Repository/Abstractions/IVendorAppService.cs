using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IVendorAppService
    {
        VendorViewModel GetVendorById(int vendorId);

        VendorViewModel GetVendorByEmail(string email);
    }
}
