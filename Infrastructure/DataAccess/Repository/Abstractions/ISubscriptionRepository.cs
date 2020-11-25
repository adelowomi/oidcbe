using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface ISubscriptionRepository
    {
        Subscription Subscribe(int userId, int organizationTypeId);

        Subscription Subscribe(int userId, int organizationTypeId, int plotId);

        Subscription SubscriptionBy(int subscriptionId);

        Offer GenerateOffer();

        Offer GenerateOffer(int plotId);

        IEnumerable<Subscription> GetAllSubscriptions();

        IEnumerable<Subscription> GetSubscriptions(int userId);
    }
}
