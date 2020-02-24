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
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class Hub_Data_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly IHubContext<ChatHub> _hubContext;
        public Hub_Data_Controller(IRepositoryWrapper RW, IHubContext<ChatHub> hubContext)
        {
            _repositoryWrapper = RW;
            _hubContext = hubContext;
        }
        [HttpGet("Get_Hub_Data", Name = "Get_Hub_Data")]
        public async void Get_Hub_Data([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            try
            {
                dynamic dd = param;
                string message = dd.message;
                string username = dd.username;
                //await _hubContext.Clients.All.SendAsync("Receive_Notification", message);
                string Connection_Id = Globalfunction.UserIdentifier.GetValue(username).ToString();
                //await _hubContext.Clients.User(Connection_Id).SendAsync("Receive_Notification", message);
                await _hubContext.Clients.Client(Connection_Id).SendAsync("Receive_Notification", message + " "+username);
                //     ChatHub CH = new ChatHub();
                //  await CH.Send_Notification(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }

}