using System;
namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface ISubscriberRepository
    {
        int GetExistingSubscribers();

        int GetNewSubscribers();

    }
}