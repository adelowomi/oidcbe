using System;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using FCM.Net;
using Microsoft.Extensions.Options;

namespace AppService.Services
{
    public class NotificationAppService : INotificationAppService
    {
        private readonly AppSettings _setting;
        private readonly IForumAppService _forumAppService;
        private readonly IUserService _userService;

        public NotificationAppService(IOptions<AppSettings> option,
                                      IUserService userService,
                                      IForumAppService forumAppService)
        {
            _setting = option.Value;
            _forumAppService = forumAppService;
            _userService = userService;
        }

        public ResponseViewModel NewNotification(ForumMessageInputModel notification)
        {
            var response = _forumAppService.CreateNewForum(notification);

            _ = SendNotification(new NotificationInputModel
            {
                Notification = new Notification
                {
                    Title = "Notification",
                    Body = notification.Message,
                },
                RegistrationIds = notification.Receivers
            }).Result;

            return response;
        }

        public ResponseViewModel RegisterToken(string token)
        {
            var user = _userService.GetCurrentLoggedOnUserAsync().Result;

            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel> SendNotification(NotificationInputModel notification)
        {
            using (var sender = new Sender(_setting.FireBaseSenderKey))
            {
                var message = new Message
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
