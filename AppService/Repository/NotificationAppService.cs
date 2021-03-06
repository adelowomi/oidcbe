using System;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using AutoMapper;
using Core.Model;
using FCM.Net;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.Extensions.Options;

namespace AppService.Services
{
    public class NotificationAppService : ResponseViewModel, INotificationAppService
    {
        /// <summary>
        /// Properties
        /// </summary>
        private readonly AppSettings _setting;
        private readonly IForumAppService _forumAppService;
        private readonly IForumRepository _forumRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        /// <param name="forumRepository"></param>
        /// <param name="forumAppService"></param>
        public NotificationAppService(IOptions<AppSettings> option,
                                      IUserService userService,
                                      IMapper mapper,
                                      IForumRepository forumRepository,
                                      IForumAppService forumAppService)
        {
            _setting = option.Value;
            _forumAppService = forumAppService;
            _userService = userService;
            _forumRepository = forumRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Notification 
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetNotifications()
        {
          var results =  _forumRepository
                .GetAllForumMessages()
                .Where(x => x.ForumMessageTypeId == (int)ForumMessageTypeEnum.NOTIFICATION)
                .ToList()
                .Select(_mapper.Map<ForumMessage, ForumMessageViewModel>);

            return Ok(results);
        }

        /// <summary>
        /// New Notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public ResponseViewModel NewNotification(ForumMessageInputModel notification)
        {
            notification.ForumMessageTypeId = (int) ForumMessageTypeEnum.NOTIFICATION;

            var response = _forumAppService.CreateNewMessageForum(notification);

            _ = SendNotification(new NotificationInputModel
            {
                Notification = new Notification
                {
                    Title = notification.Title,
                    Body = notification.Message,
                },

                RegistrationIds = notification.Receivers

            }).Result;

            return response;
        }

        /// <summary>
        /// Register Firebase Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ResponseViewModel RegisterToken(string token)
        {
            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            user.FireBaseToken = token;

            _ = _userService.UpdateCurrentUserAsync(user).Result;

            return Ok();
        }

        public async Task<ResponseViewModel> SendNotification(NotificationInputModel notification)
        {
            using (var sender = new Sender(_setting.FireBaseSenderKey))
            {
                var message = new FCM.Net.Message
                {
                    RegistrationIds = notification.RegistrationIds,

                    Notification = notification.Notification
                };

                var result = await sender.SendAsync(message);

                Console.WriteLine($"Success: {result.MessageResponse.Success}");

                //var json = "{\"notification\":{\"title\":\"json message\",\"body\":\"works like a charm!\"},\"to\":\"" + registrationId + "\"}";
                //result = await sender.SendAsync(json);
                //Console.WriteLine($"Success: {result.MessageResponse.Success}");
            }

            return ResponseViewModel.Ok();
        }
    }
}
