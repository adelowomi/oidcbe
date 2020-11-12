using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IVendorRepository
    {
        int GetCurrentVendors();

        int GetNewVendor();

        ICollection<AppUser> GetAllExistingVendors();

        ICollection<AppUser> GetNewVendors();
    }
}
