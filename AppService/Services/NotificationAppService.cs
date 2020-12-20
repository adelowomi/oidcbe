using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Services.Abstractions;
using FCM.Net;
using Microsoft.Extensions.Options;

namespace AppService.Services
{
    public class NotificationAppService : INotificationAppService
    {
        private readonly AppSettings _setting;

        public NotificationAppService(IOptions<AppSettings> option)
        {
            _setting = option.Value;
        }

        public async Task<ResponseViewModel> SendNotification(NotificationInputModel notification)
        {
            var registrationId = "ID generated when device is registered in FCM / ID gerado quando o device é registrado no FCM";

            //You can get the server Key by accessing the url/ Você pode obter a chave do servidor acessando a url 
            //https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";
            using (var sender = new Sender("serverKey"))
            {
                var message = new Message
                {
                    RegistrationIds = new List<string> { registrationId },
                    Notification = new Notification
                    {
                        Title = "Test from FCM.Net",
                        Body = $"Hello World@!{DateTime.Now.ToString()}"
                    }
                };
                var result = await sender.SendAsync(message);
                Console.WriteLine($"Success: {result.MessageResponse.Success}");

                var json = "{\"notification\":{\"title\":\"json message\",\"body\":\"works like a charm!\"},\"to\":\"" + registrationId + "\"}";
                result = await sender.SendAsync(json);
                Console.WriteLine($"Success: {result.MessageResponse.Success}");
            }

            return ResponseViewModel.Ok();
        }
    }
}
