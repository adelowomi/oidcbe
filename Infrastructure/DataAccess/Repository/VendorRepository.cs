using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DataAccess.Repository
{
    public class VendorRepository : BaseRepository<Subscription>, IVendorRepository
    {

        private readonly UserManager<AppUser> _userManager;

        public VendorRepository(AppDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public ICollection<AppUser> GetAllExistingVendors()
        {
            var users = _userManager.GetUsersInRoleAsync("VENDOR").Result;

            return users.Where(x => x.IsExisting == true).ToList();
        }

        public int GetCurrentVendors()
        {
            return GetAllExistingVendors().Count();
        }

        public int GetNewVendor()
        {
            return GetNewVendors().Count();
        }

        public ICollection<AppUser> GetNewVendors()
        {
            var users = _userManager.GetUsersInRoleAsync("VENDOR").Result;

            return users.Where(x => !x.IsExisting).ToList();
        }
    }
}
