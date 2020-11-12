using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface ISubscriberRepository
    {
        int GetExistingSubscribers();

        int GetNewSubscribers();

        ICollection<AppUser> GetAllExistingSubcribers();

        ICollection<AppUser> GetAllNewSubscribers();
    }
}