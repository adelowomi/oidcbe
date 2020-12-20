using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IForumAppService
    {
        /// <summary>
        /// Get All Forum Messages
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetAllForumMessages();

        /// <summary>
        /// Create A New Message Forum
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        ResponseViewModel CreateNewMessageForum(ForumMessageInputModel message);

        /// <summary>
        /// Get Forum By Forum Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseViewModel GetById(int id);

        /// <summary>
        /// Get Forum By Message Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        ResponseViewModel GetItById(int messageId);

        /// <summary>
        /// Get Forum By Message Id 2nd +OverLoad Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forumId"></param>
        /// <returns></returns>
        ResponseViewModel GetItById(int id, int forumId);

        /// <summary>
        /// Get All Forums
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetForums();

        /// <summary>
        /// Get Forum Message Types
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetForumMessageTypes();

        /// <summary>
        /// Get Forum Subscriptions
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetForumSubscriptions();

        /// <summary>
        /// Get Forum Subscriptions 2nd +OverLoad Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseViewModel GetForumSubscriptions(int id);

        /// <summary>
        /// Get Forum Subscriptsions By User Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponseViewModel GetForumSubscriptions(int id, int userId);

        /// <summary>
        /// Subscribe To A Forum
        /// </summary>
        /// <param name="forumId"></param>
        /// <returns></returns>
        Task<ResponseViewModel> SubscribeToForumAsync(int forumId);
    }
}
