using System;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class SubscriberRepository : BaseRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(AppDbContext context) : base(context)
        {

        }

        public int GetExistingSubscribers()
        {
            throw new NotImplementedException();
        }

        public int GetNewSubscribers()
        {
            throw new NotImplementedException();
        }
    }
}
