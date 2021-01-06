using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IOfferAppService
    {
        /// <summary>
        /// Geenerate Offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        ResponseViewModel GeneratorOffer(OfferInputModel offer);

        /// <summary>
        /// Get All Offers
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetAllOffers();

        /// <summary>
        /// Get Offer By
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        ResponseViewModel GetOfferBy(int offerId);

        /// <summary>
        /// Get Offer By
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="plotId"></param>
        /// <returns></returns>
        ResponseViewModel GetOfferBy(int offerId, int plotId);
    }
}
