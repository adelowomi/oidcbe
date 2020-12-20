using System;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Services.Abstractions
{
    public interface INotificationAppService
    {
        Task<ResponseViewModel> SendNotification(NotificationInputModel notification);

        ResponseViewModel NewNotification(ForumMessageInputModel notification);

        ResponseViewModel RegisterToken(string token);
    }
}
