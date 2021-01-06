using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.Repository.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class OffersController : ControllerBase
    {
        /// <summary>
        /// Properties
        /// </summary>
        private readonly IOfferAppService _offerAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="offerAppService"></param>
        public OffersController(IOfferAppService offerAppService)
        {
            _offerAppService = offerAppService;
        }

        /// <summary>
        /// Generate Offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/offer")]
        public IActionResult GenerateOffer([FromBody] OfferInputModel offer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_offerAppService.GeneratorOffer(offer));
        }

        /// <summary>
        /// Get All Offers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/offers")]
        public IActionResult GetAllOffers()
        {
            return Ok(_offerAppService.GetAllOffers());
        }

        /// <summary>
        /// Get Offer By OfferId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/offer/{offerId}")]
        public IActionResult GetOfferBy(int offerId)
        {
            return Ok(_offerAppService.GetOfferBy(offerId));
        }

        /// <summary>
        /// Get Offer By OfferId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/offer/plot/{plotId}")]
        public IActionResult GetOfferByPlot(int plotId)
        {
            return Ok(_offerAppService.GetOfferBy(0, plotId));
        }
    }
}
