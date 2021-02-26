using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IOfferRepository
    {
        public Offer CreateOffer (Offer offer);

        public IEnumerable<Offer> GetOffers();

        public Offer UpdateOffer(Offer offer);
    }
}
