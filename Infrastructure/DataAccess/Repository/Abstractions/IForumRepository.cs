using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IForumRepository
    {
        IEnumerable<ForumMessage> GetAllForumMessages();

        ForumMessage CreateNewForum(ForumMessage message);

        ForumMessage GetById(int id);

        ForumMessage GetItById(int messageId);

        IEnumerable<ForumMessage> GetItById(int id, int forumId);

        IEnumerable<Forum> GetForums();

        IEnumerable<ForumMessageType> GetForumMessageTypes();

        IEnumerable<ForumSubscription> GetForumSubscriptions();

        ForumSubscription GetForumSubscriptions(int id);

        IEnumerable<ForumSubscription> GetForumSubscriptions(int id, int userId);
    }
}
