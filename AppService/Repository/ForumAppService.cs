using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Extensions;
using AppService.Repository.Abstractions;
using AutoMapper;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class ForumAppService : ResponseViewModel, IForumAppService
    {
        protected readonly IForumRepository _forumRepository;
        protected readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="forumRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userManager"></param>
        public ForumAppService(IForumRepository forumRepository,
                                IMapper mapper,
                                IHttpContextAccessor httpContextAccessor,
                                UserManager<AppUser> userManager)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        /// <summary>
        /// Create New Forum Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseViewModel CreateNewMessageForum(ForumMessageInputModel message)
        {
            var forum = _forumRepository.GetForums().FirstOrDefault(x => x.Id == message.ForumId);

            if(forum == null && message.ForumMessageTypeId != (int) ForumMessageTypeEnum.NOTIFICATION)
            {
                return Failed(ResponseMessageViewModel.INVALID_FORUM, ResponseErrorCodeStatus.INVALID_FORUM);
            }

            var forumType = _forumRepository.GetForumMessageTypes().FirstOrDefault(x => x.Id == message.ForumMessageTypeId);

            if(forumType == null)
            {
                return Failed(ResponseMessageViewModel.INVALID_FORUM_TYPE, ResponseErrorCodeStatus.INVALID_FORUM_TYPE);
            }

            var result = _mapper.Map<ForumMessageInputModel, ForumMessage>(message);

            if (message.ForumMessageTypeId == (int)ForumMessageTypeEnum.NOTIFICATION)
            {
                result.ForumId = null;
            }

            var query = _forumRepository.CreateNewForum(result);

            var mappedResult = _mapper.Map<ForumMessage, ForumMessageViewModel>(query);

            return Ok(mappedResult);
        }

        /// <summary>
        /// Get All Forum Messages
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetAllForumMessages()
        {
            return Ok(_forumRepository.GetAllForumMessages()
                        .Select(_mapper.Map<ForumMessage, ForumMessageViewModel>));
        }

        /// <summary>
        /// Get Forum Messages By User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel GetById(int id)
        {
            return GetAllForumMessages();
        }

        /// <summary>
        /// Get Forum Message Types
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetForumMessageTypes()
        {
            var results = _forumRepository.GetForumMessageTypes().Select(_mapper.Map<ForumMessageType, ForumMessageTypeViewModel>);

            return Ok(results);
        }

        /// <summary>
        /// Get Forums
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetForums()
        {
            return Ok(_forumRepository.GetForums()
                         .Select(_mapper.Map<Forum, ForumViewModel>));
        }


        /// <summary>
        /// Get Forum Subscriptions
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetForumSubscriptions()
        {
            return Ok(_forumRepository.GetForumSubscriptions()
                        .Select(_mapper.Map<ForumSubscription, ForumSubscriptionViewModel>));
        }

        /// <summary>
        /// Get Forum Subscription By User Id 1 +OverLoad Methods
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel GetForumSubscriptions(int id)
        {
            return Ok(_mapper.Map<ForumSubscription,
                            ForumSubscriptionViewModel>
                                (_forumRepository.GetForumSubscriptions(id)));
        }

        /// <summary>
        /// Get Forum Subscription By User Id 2 +OverLoad Methods
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResponseViewModel GetForumSubscriptions(int id, int userId)
        {
            return Ok(_forumRepository.GetForumSubscriptions(id, userId)
                        .Select(_mapper.Map<ForumSubscription, ForumSubscriptionViewModel>));
        }

        /// <summary>
        /// Get Forum Message By Message Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public ResponseViewModel GetItById(int messageId)
        {
            return Ok(_mapper.Map<ForumMessage,
                            ForumMessageViewModel>(
                            _forumRepository.GetItById(messageId)));
                       
        }

        /// <summary>
        /// Get Forum Using Method +OverLoad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forumId"></param>
        /// <returns></returns>
        public ResponseViewModel GetItById(int id, int forumId)
        {
            return Ok(_forumRepository.GetItById(id, forumId)
                        .Select(_mapper.Map<ForumMessage, ForumMessageViewModel>));
        }

        /// <summary>
        /// Subscribe To Forum
        /// </summary>
        /// <param name="forumId"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> SubscribeToForumAsync(int forumId)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            var result = _forumRepository.SubscribeToForum(user.Id, forumId);

            var mappedResult = _mapper.Map<ForumSubscription, ForumSubscriptionViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
