using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class SubscriberRepository : BaseRepository<Subscription>, ISubscriberRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IPlotRepository _plotRepository;

        public SubscriberRepository(AppDbContext context, UserManager<AppUser> userManager, IPlotRepository plotRepository) : base(context)
        {
            _userManager = userManager;
            _plotRepository = plotRepository;
        }

        public SubscriberIdentityResult CreateNewSubscriber(AppUser user)
        {
            var result = _userManager.CreateAsync(user, "Password").Result;

            return new SubscriberIdentityResult { AppUser = user, IdentityResult = result };
        }

        public ICollection<AppUser> GetAllExistingSubcribers()
        {
            //   var users = _userManager.GetUsersInRoleAsync("VENDOR").Result;

            var users = _context.Users 
                .Include(x => x.NextOfKin);

           
            foreach (var user in users)
            {
                var subscriptions =
                    _context
                    .Subscriptions
                    .Include(x => x.Offer)
                    .Include(x => x.Offer.Plot)
                    .Include(x => x.Offer.OfferStatus)
                    .Include(x => x.OrganizationType)
                    .Include(x => x.SubscriptionStatus)
                    .Where(x => x.AppUserId == user.Id).ToList();

                user.Subscriptions = subscriptions;
                user.Plots = _plotRepository.GetPlots().Where(x => x.AppUserId == user.Id).ToList();

            }

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


    public class SubscriberIdentityResult
    {
        public IdentityResult IdentityResult { get; set; }

        public AppUser AppUser { get; set; }
    }
}
