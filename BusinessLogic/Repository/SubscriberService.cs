using System;
using System.Collections.Generic;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Repository
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public SubscriberIdentityResult CreateSubcribers(AppUser user)
        {
            var result = _subscriberRepository.CreateNewSubscriber(user);

            return result;
        }

        public IEnumerable<AppUser> GetExistingSubscribers()
        {
            return _subscriberRepository.GetAllExistingSubcribers();
        }
    }
}
