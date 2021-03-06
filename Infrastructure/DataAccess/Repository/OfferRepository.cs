using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AppDbContext context) : base(context)
        {
            
        }

        public Offer CreateOffer(Offer offer)
        {
            var result = CreateAndReturn(offer);

            return GetOffers().FirstOrDefault(x => x.Id == offer.Id);
        }

        public IEnumerable<Offer> GetOffers()
        {
            var result = _context.Offers
                .Include(x => x.Plot)
                .Include(x => x.Payments)
                .Include(x => x.Plot.AppUser)
                .Include(x => x.OfferStatus);

            return result;
        }

        public Offer UpdateOffer(Offer offer)
        {
            var result = Update(offer);

            return result;
        }
    }
}
