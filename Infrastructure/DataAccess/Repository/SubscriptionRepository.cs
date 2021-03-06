using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {

        public SubscriptionRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Subscription> GetSubscriptions(int userId)
        {
            return GetAllSubscriptions().Where(x => x.AppUserId == userId);
        }

        public Subscription Subscribe(int userId, int organizationTypeId)
        {
            var offer = GenerateOffer();

            var result = CreateAndReturn(new Subscription
            {
                OfferId = offer.Id,
                AppUserId = userId,
                OrganizationTypeId = organizationTypeId,
                SubscriptionStatusId = (int) SubscriptionStatusEnum.PENDING
            });


            return GetAllSubscriptions().FirstOrDefault(x => x.Id == result.Id);
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            var query = _context.Subscriptions
               .Include(x => x.Offer)
               .Include(x => x.Offer.OfferStatus)
               .Include(x => x.Offer.Plot)
               .Include(x => x.OrganizationType)
               .Include(x => x.Offer.Plot.PlotType)
               .Include(x => x.SubscriptionStatus);
              
            return query;
        }

        public Subscription Subscribe(int userId, int organizationTypeId, int plotId)
        {
            var offer = GenerateOffer(plotId);

            var result = CreateAndReturn(new Subscription
            {
                OfferId = offer.Id,
                AppUserId = userId,
                OrganizationTypeId = organizationTypeId,
                SubscriptionStatusId = (int) SubscriptionStatusEnum.PENDING,
            });

            return GetAllSubscriptions().FirstOrDefault(x => x.Id == result.Id);
        }

        public Offer GenerateOffer()
        {
            var plot = _context.Plots.FirstOrDefault(x => x.IsAvailable == true);

            var offer = new Offer
            {
                PlotId = plot.Id,
                OfferStatusId = (int) OfferStatusEnum.PENDING,
                IsEnabled = true,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            plot.IsAvailable = false;
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        public Offer GenerateOffer(int plotId)
        {
            var offer = new Offer
            {
                PlotId = plotId,
                OfferStatusId = (int)OfferStatusEnum.PENDING,
                IsEnabled = true,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        public Subscription SubscriptionBy(int subscriptionId)
        {
            return GetAllSubscriptions().FirstOrDefault(x => x.Id == subscriptionId);
        }

        public Payment LogPayment()
        {
            throw new NotImplementedException();
        }

        
    }
}
