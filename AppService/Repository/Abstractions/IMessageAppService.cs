using System;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface IMessageAppService
    {
        ResponseViewModel GetConversation();

        ResponseViewModel GetConversation(int userId);

        ResponseViewModel GetMessageStatues();

        ResponseViewModel GetMessageTypes();

        ResponseViewModel SendMessage(MessageInputModel message);
    }
}
