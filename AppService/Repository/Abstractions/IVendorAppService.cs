using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IVendorAppService
    {
        /// <summary>
        /// Abstract Interface Method To Get Vendor By Id
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        VendorViewModel GetVendorById(int vendorId);

        /// <summary>
        /// Abstract Interface Method To Get Vendor By Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        VendorViewModel GetVendorByEmail(string email);
    }
}
