using System;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IVendorRepository
    {
        int GetCurrentVendors();

        int GetNewVendor();
    }
}
