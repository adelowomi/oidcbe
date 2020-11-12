using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DataAccess.Repository
{
    public class SubscriberRepository : BaseRepository<Subscription>, ISubscriberRepository
    {

        private readonly UserManager<AppUser> _userManager;

        public SubscriberRepository(AppDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public ICollection<AppUser> GetAllExistingSubcribers()
        {
            //   var users = _userManager.GetUsersInRoleAsync("VENDOR").Result;

            var users = _context.Users;
            return users.ToList();
            //return users.Where(x => x.IsExisting == true).ToList();
        }

        public ICollection<AppUser> GetAllNewSubscribers()
        {
            var users = _userManager.GetUsersInRoleAsync("VENDOR").Result;

            return users.Where(x => !x.IsExisting).ToList();
        }

        public int GetExistingSubscribers()
        {
            return GetAllExistingSubcribers().Count();
        }

        public int GetNewSubscribers()
        {
            return GetAllNewSubscribers().Count();
        }
    }
}
