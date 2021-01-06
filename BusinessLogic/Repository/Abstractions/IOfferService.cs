using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IOfferService
    {
        public Offer GenerateOffer(Offer offer);

        public IEnumerable<Offer> GetAllOffers();

        public Offer UpdateAnOffer(Offer offer);
    }
}
