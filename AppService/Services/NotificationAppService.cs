using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Services.Abstractions;

namespace AppService.Services
{
    public class NotificationAppService : INotificationAppService
    {
        public NotificationAppService()
        {

        }

        public ResponseViewModel SendNotification(NotificationTypeInputModel notificationType)
        {
            throw new NotImplementedException();
        }
    }
}
