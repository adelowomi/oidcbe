using System;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;

namespace AppService.Repository
{
    public class VendorAppService : IVendorAppService
    {
        private IVendorService _vendorService;

        public VendorAppService (IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public VendorViewModel GetVendorBy(string email)
        {
            throw new NotImplementedException();
        }

        public VendorViewModel GetVendorByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public VendorViewModel GetVendorById(int vendorId)
        {
            throw new NotImplementedException();
        }
    }
}
