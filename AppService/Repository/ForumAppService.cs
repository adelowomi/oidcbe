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

        public ResponseViewModel CreateNewForum(ForumMessageInputModel message)
        {
            var forum = _forumRepository.GetForums().FirstOrDefault(x => x.Id == message.ForumId);

            if(forum == null)
            {
                return Failed(ResponseMessageViewModel.INVALID_FORUM, ResponseErrorCodeStatus.INVALID_FORUM);
            }

            var forumType = _forumRepository.GetForumMessageTypes().FirstOrDefault(x => x.Id == message.ForumMessageTypeId);

            if(forumType == null)
            {
                return Failed(ResponseMessageViewModel.INVALID_FORUM_TYPE, ResponseErrorCodeStatus.INVALID_FORUM_TYPE);
            }

            var result = _mapper.Map<ForumMessageInputModel, ForumMessage>(message);

            var query = _forumRepository.CreateNewForum(result);

            var mappedResult = _mapper.Map<ForumMessage, ForumMessageViewModel>(query);

            return Ok(mappedResult);
        }

        public ResponseViewModel GetAllForumMessages()
        {
            return Ok(_forumRepository.GetAllForumMessages()
                        .Select(_mapper.Map<ForumMessage, ForumMessageViewModel>));
        }

        public ResponseViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel GetForumMessageTypes()
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel GetForums()
        {
            return Ok(_forumRepository.GetForums()
                         .Select(_mapper.Map<Forum, ForumViewModel>));
        }

        public ResponseViewModel GetForumSubscriptions()
        {
            return Ok(_forumRepository.GetForumSubscriptions()
                        .Select(_mapper.Map<ForumSubscription, ForumSubscriptionViewModel>));
        }

        public ResponseViewModel GetForumSubscriptions(int id)
        {
            return Ok(_mapper.Map<ForumSubscription,
                            ForumSubscriptionViewModel>
                                (_forumRepository.GetForumSubscriptions(id)));
        }

        public ResponseViewModel GetForumSubscriptions(int id, int userId)
        {
            return Ok(_forumRepository.GetForumSubscriptions(id, userId)
                        .Select(_mapper.Map<ForumSubscription, ForumSubscriptionViewModel>));
        }

        public ResponseViewModel GetItById(int messageId)
        {
            return Ok(_mapper.Map<ForumMessage,
                            ForumMessageViewModel>(
                            _forumRepository.GetItById(messageId)));
                       
        }

        public ResponseViewModel GetItById(int id, int forumId)
        {
            return Ok(_forumRepository.GetItById(id, forumId)
                        .Select(_mapper.Map<ForumMessage, ForumMessageViewModel>));
        }

        public async Task<ResponseViewModel> SubscribeToForumAsync(int forumId)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>().ToString());

            var result = _forumRepository.SubscribeToForum(user.Id, forumId);

            var mappedResult = _mapper.Map<ForumSubscription, ForumSubscriptionViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
