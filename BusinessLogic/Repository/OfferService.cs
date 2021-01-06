using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class OfferService : IOfferService
    {
        protected IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public Offer GenerateOffer(Offer offer)
        {
            return _offerRepository.CreateOffer(offer);
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            return _offerRepository.GetOffers();
        }

        public Offer UpdateAnOffer(Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
