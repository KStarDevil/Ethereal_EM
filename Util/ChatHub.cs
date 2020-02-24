using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;
using Operational.Encrypt;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;

namespace Ethereal_EM
{
    public class ChatHub : Hub
    {

        public override Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"];
            var connectionId = Context.ConnectionId;
            //UserHandler.ConnectedIds.Add(Context.ConnectionId);
            Globalfunction.UserIdentifier.Add(username, connectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception ex)
        {
            var username = Context.GetHttpContext().Request.Query["username"];
            var connectionId = Context.ConnectionId;
            //UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            Globalfunction.UserIdentifier.Remove(username);
            return base.OnDisconnectedAsync(ex);
        }
        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Send_Notification(string message)
        {
            try
            {
                await Clients.All.SendAsync("Receive_Notification", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async void HelloServer()
        {
            await Clients.All.SendAsync("Hello message to all clients");
        }

    }
}