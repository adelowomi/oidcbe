using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface ISubscriptionAppService
    {
        Task<SubscriptionViewModel> MakeSubscription();

        Task<SubscriptionViewModel> MakeSubscription(SubscriptionInputModel model);

        Task<SubscriptionViewModel> GetCurrentSubscription();

        OfferViewModel GenerateSubscriptionOffer();

        OfferViewModel GenerateSubscriptionOffer(int plotId);

        IEnumerable<SubscriptionViewModel> GetSubscriptions();

        IEnumerable<SubscriptionViewModel> GetSubscriptions(int userId);
    }
}
