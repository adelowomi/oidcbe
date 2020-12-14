using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IForumAppService
    {
        ResponseViewModel GetAllForumMessages();

        ResponseViewModel CreateNewForum(ForumMessageInputModel message);

        ResponseViewModel GetById(int id);

        ResponseViewModel GetItById(int messageId);

        ResponseViewModel GetItById(int id, int forumId);

        ResponseViewModel GetForums();

        ResponseViewModel GetForumMessageTypes();

        ResponseViewModel GetForumSubscriptions();

        ResponseViewModel GetForumSubscriptions(int id);

        ResponseViewModel GetForumSubscriptions(int id, int userId);

        Task<ResponseViewModel> SubscribeToForumAsync(int forumId);
    }
}
