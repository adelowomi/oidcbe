using System;
using System.Collections.Generic;
using Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface ISubscriberRepository
    {
        int GetExistingSubscribers();

        int GetNewSubscribers();

        SubscriberIdentityResult CreateNewSubscriber(AppUser user);

        ICollection<AppUser> GetAllExistingSubcribers();

        ICollection<AppUser> GetAllNewSubscribers();
    }
}