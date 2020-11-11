using System;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using BusinessLogic.Repository.Abstractions;

namespace AppService.Repository
{
    /// <summary>
    /// Concrete Implementation Of IVendorAppService
    /// </summary>
    public class VendorAppService : IVendorAppService
    {
        private IVendorService _vendorService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vendorService"></param>
        public VendorAppService (IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        /// <summary>
        /// Get Vendor By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public VendorViewModel GetVendorBy(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Vendor By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public VendorViewModel GetVendorByEmail(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Vendor By Vendor's Id
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public VendorViewModel GetVendorById(int vendorId)
        {
            throw new NotImplementedException();
        }
    }
}
