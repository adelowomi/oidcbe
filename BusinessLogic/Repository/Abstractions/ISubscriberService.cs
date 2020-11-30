using System;
using System.Collections.Generic;
using Core.Model;
using Infrastructure.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Repository.Abstractions
{
    public interface ISubscriberService
    {
        IEnumerable<AppUser> GetExistingSubscribers();

        SubscriberIdentityResult CreateSubcribers(AppUser user);
    }
}
