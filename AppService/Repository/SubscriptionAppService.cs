using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class SubscriptionAppService : ISubscriptionAppService
    {

        public readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly UserManager<AppUser> _userManager;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionAppService(ISubscriptionService subscriptionService,
                                      IMapper mapper,
                                      IHttpContextAccessor httpContextAccessor,
                                      UserManager<AppUser> userManager)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public OfferViewModel GenerateSubscriptionOffer()
        {
          return  _mapper.Map<Offer,OfferViewModel>(_subscriptionService.GenerateOffer());
        }

        public OfferViewModel GenerateSubscriptionOffer(int plotId)
        {
            return _mapper.Map<Offer, OfferViewModel>(_subscriptionService.GenerateOffer());
        }

        public IEnumerable<SubscriptionViewModel> GetSubscriptions()
        {
            return _subscriptionService.GetAllSubscriptions().Select(_mapper.Map<Subscription, SubscriptionViewModel>);
        }

        public IEnumerable<SubscriptionViewModel> GetSubscriptions(int userId)
        {
            return _subscriptionService.GetSubscriptions(userId).Select(_mapper.Map<Subscription, SubscriptionViewModel>);
        }

        public async Task<SubscriptionViewModel> MakeSubscription()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());
            var result = _subscriptionService.Subscribe(currentUser.Id, currentUser.OrganizationTypeId ?? 1);
            return _mapper.Map<Subscription, SubscriptionViewModel>(result);
        }

        public async Task<SubscriptionViewModel> MakeSubscription(SubscriptionInputModel model)
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _mapper.Map<Subscription, SubscriptionViewModel>(_subscriptionService.Subscribe(currentUser.Id, currentUser.OrganizationTypeId ?? 1, model.PlotId));
        }

        public async Task<SubscriptionViewModel> GetCurrentSubscription()
        {
            var currentUser = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            return _mapper.Map<Subscription, SubscriptionViewModel>(_subscriptionService.SubscriptionBy(currentUser.Id));
        }
    }
}
