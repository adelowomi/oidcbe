using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class SubscriptionAppService : ResponseViewModel, ISubscriptionAppService
    {

        public readonly IMapper _mapper;
        private readonly IPlotService _plotService;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly UserManager<AppUser> _userManager;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IOTPService _otpService;

        public SubscriptionAppService(ISubscriptionService subscriptionService,
                                      IMapper mapper,
                                      IOTPService otpService,
                                      IPlotService plotService,
                                      IHttpContextAccessor httpContextAccessor,
                                      UserManager<AppUser> userManager)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _otpService = otpService;
            _plotService = plotService;
        }

        /// <summary>
        /// Generate Subscription Offer
        /// </summary>
        /// <returns></returns>
        public OfferViewModel GenerateSubscriptionOffer()
        {
          return  _mapper.Map<Offer,OfferViewModel>(_subscriptionService.GenerateOffer());
        }

        /// <summary>
        /// Generate Subscription Offer
        /// </summary>
        /// <param name="plotId"></param>
        /// <returns></returns>
        public OfferViewModel GenerateSubscriptionOffer(int plotId)
        {
            return _mapper.Map<Offer, OfferViewModel>(_subscriptionService.GenerateOffer());
        }

        /// <summary>
        /// Get Subscriptions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubscriptionViewModel> GetSubscriptions()
        {
            return _subscriptionService.GetAllSubscriptions().Select(_mapper.Map<Subscription, SubscriptionViewModel>);
        }

        /// <summary>
        /// Get Subscriptions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SubscriptionViewModel> GetSubscriptions(int userId)
        {
            return _subscriptionService.GetSubscriptions(userId).Select(_mapper.Map<Subscription, SubscriptionViewModel>);
        }

        /// <summary>
        /// Make Subscription
        /// </summary>
        /// <returns></returns>
        public async Task<SubscriptionViewModel> MakeSubscription()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
            var result = _subscriptionService.Subscribe(currentUser.Id, currentUser.OrganizationTypeId ?? 1);
            return _mapper.Map<Subscription, SubscriptionViewModel>(result);
        }

        /// <summary>
        /// Make Subscription
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> MakeSubscription(SubscriptionInputModel model)
        {
            var plot = _plotService.AllPlots().FirstOrDefault(x => x.Id == model.PlotId);

            if (plot == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return Ok(_mapper.Map<Subscription, SubscriptionViewModel>(_subscriptionService.Subscribe(currentUser.Id, currentUser.OrganizationTypeId ?? 1, model.PlotId)));
        }

        /// <summary>
        /// Get Current Subscription
        /// </summary>
        /// <returns></returns>
        public async Task<SubscriptionViewModel> GetCurrentSubscription()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _mapper.Map<Subscription, SubscriptionViewModel>(_subscriptionService.SubscriptionBy(currentUser.Id));
        }
    }
}
