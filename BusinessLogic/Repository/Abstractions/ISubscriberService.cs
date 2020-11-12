using System;
using System.Collections.Generic;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface ISubscriberService
    {
        IEnumerable<AppUser> GetExistingSubscribers();
    }
}
