using System;
using BusinessLogic.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionAppService(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
    }
}
