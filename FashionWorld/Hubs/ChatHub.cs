using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionWorld.Models;
using Microsoft.AspNetCore.SignalR;
namespace FashionWorld.Hubs
{
    public class ChatHub : Hub
    {
     
        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
