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


namespace Ethereal_EM
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(
              "newMessage", Context.User.Identity.Name,
                    message);
        }
    }
}