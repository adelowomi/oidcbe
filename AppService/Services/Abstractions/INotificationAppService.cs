using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Services.Abstractions
{
    public interface INotificationAppService
    {
        ResponseViewModel SendNotification(NotificationTypeInputModel notificationType);
    }
}
