using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class ForumRepository : BaseRepository<ForumMessage>, IForumRepository
    {
        public ForumRepository(AppDbContext context) : base(context)
        {

        }

        public ForumMessage CreateNewForum(ForumMessage message)
        {
            var result = CreateAndReturn(message);

            return GetItById(result.Id);
        }

        public IEnumerable<ForumMessage> GetAllForumMessages()
        {
            var result = _context.ForumMessages.Include(x => x.Forum).Include(x => x.ForumMessageType);

            return result;
        }

        public IEnumerable<ForumMessage> GetItById(int id, int forumId)
        {
            return GetAllForumMessages().Where(x => x.ForumId == forumId);
        }

        public IEnumerable<ForumMessageType> GetForumMessageTypes()
        {
            var result = _context.ForumMessageTypes.ToList();

            return result;
        }

        public IEnumerable<Forum> GetForums()
        {
            var result = _context.Forums.ToList();

            return result;
        }

        public IEnumerable<ForumSubscription> GetForumSubscriptions()
        {
            var result = _context.ForumSubscriptions.Include(x => x.Forum).Include(x => x.AppUser);

            return result;
        }

        public ForumSubscription GetForumSubscriptions(int id)
        {
            var result = GetForumSubscriptions().FirstOrDefault(x => x.Id == id);

            return result;
        }

        public IEnumerable<ForumSubscription> GetForumSubscriptions(int id, int userId)
        {
            var result = GetForumSubscriptions().Where(x => x.AppUserId == userId);

            return result;
        }

        public ForumMessage GetItById(int messageId)
        {
            var result = GetAllForumMessages().FirstOrDefault(x => x.Id == messageId);

            return result;
        }

        public ForumSubscription SubscribeToForum(int id, int userId)
        {
            var result =_context.ForumSubscriptions.Add(new ForumSubscription
            {
                AppUserId = userId,
                ForumId = id
            });

            Save();

            return GetForumSubscriptions(result.Entity.Id);
        }
    }
}
