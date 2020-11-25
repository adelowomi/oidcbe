using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Offer GenerateOffer()
        {
            return _subscriptionRepository.GenerateOffer();
        }

        public Offer GenerateOffer(int plotId)
        {
            return _subscriptionRepository.GenerateOffer(plotId);
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAllSubscriptions();
        }

        public IEnumerable<Subscription> GetSubscriptions(int userId)
        {
            return _subscriptionRepository.GetSubscriptions(userId);
        }

        public Subscription Subscribe(int userId, int organizationTypeId)
        {
            return _subscriptionRepository.Subscribe(userId, organizationTypeId);
        }

        public Subscription Subscribe(int userId, int organizationTypeId, int plotId)
        {
            return _subscriptionRepository.Subscribe(userId, organizationTypeId, plotId);
        }

        public Subscription SubscriptionBy(int subscriptionId)
        {
            return _subscriptionRepository.SubscriptionBy(subscriptionId);
        }
    }
}
