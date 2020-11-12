using System;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(AppDbContext context) : base(context)
        {

        }

        public int GetCurrentVendors()
        {
            throw new NotImplementedException();
        }

        public int GetNewVendor()
        {
            throw new NotImplementedException();
        }
    }
}
