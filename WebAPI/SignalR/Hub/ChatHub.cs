using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebAPI.SignalR.Hub
{
    public class ChatHub : DynamicHub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
