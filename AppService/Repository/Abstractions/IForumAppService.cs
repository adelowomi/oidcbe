using System;
using System.Collections.Generic;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IForumAppService
    {
        IEnumerable<ForumMessageViewModel> GetAllForumMessages();

        ForumMessageViewModel CreateNewForum(ForumMessageInputModel message);

        ForumMessageViewModel GetById(int id);

        ForumMessageViewModel GetItById(int messageId);

        IEnumerable<ForumMessageViewModel> GetItById(int id, int forumId);

        IEnumerable<ForumViewModel> GetForums();

        IEnumerable<ForumMessageTypeViewModel> GetForumMessageTypes();

        IEnumerable<ForumSubscriptionViewModel> GetForumSubscriptions();

        ForumSubscriptionViewModel GetForumSubscriptions(int id);

        IEnumerable<ForumSubscriptionViewModel> GetForumSubscriptions(int id, int userId);

        ForumSubscriptionViewModel SubscribeToForum(int forumId);
    }
}
