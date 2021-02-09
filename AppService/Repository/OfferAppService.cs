using System;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class OfferAppService : ResponseViewModel, IOfferAppService
    {
        protected readonly IOfferService _offerService;
        protected readonly IMapper _mapper;
        protected readonly IUserService _userService;

        public OfferAppService(IOfferService offerService, IMapper mapper, IUserService userService)
        {
            _offerService = offerService;
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Generate Offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        public ResponseViewModel GeneratorOffer(OfferInputModel offer)
        {
            var data = _mapper.Map<OfferInputModel, Offer>(offer);

            var mapped = _offerService.GenerateOffer(data);

            var result = _mapper.Map<Offer, OfferViewModel>(mapped);

            return Ok(result);
            
        }

        /// <summary>
        /// Get All Offers
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetAllOffers()
        {
            var mapped = _offerService.GetAllOffers().Select(_mapper.Map<Offer, OfferViewModel>);

            return Ok(mapped);
        }

        /// <summary>
        /// Get Offer By
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        public ResponseViewModel GetOfferBy(int offerId)
        {
            var result = _offerService.GetAllOffers().FirstOrDefault(x => x.Id == offerId);

            return Ok(_mapper.Map<Offer, OfferViewModel>(result));
        }

        /// <summary>
        /// Get Offer By
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public ResponseViewModel GetOfferBy(int offerId, int plotId)
        {
            var result = _offerService.GetAllOffers().FirstOrDefault(x => x.PlotId == plotId);

            return Ok(_mapper.Map<Offer, OfferViewModel>(result));
        }
    }
}
