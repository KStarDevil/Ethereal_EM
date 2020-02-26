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
using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;
using System.Web;
using System.Web.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class EmailTemplate_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public EmailTemplate_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        // [HttpPost("Send_Message", Name = "Send_Message")]
        // public async Task Send_Message([FromBody] Newtonsoft.Json.Linq.JObject param)
        // {
        //     var message = new MailMessage();
        //     message.To.Add(new MailAddress(param["user_email"].ToString()+"<"+param["from_email"].ToString()+">"));
        //     message.From = new MailAddress("Aethereal Systems <systems.ethereal@gmail.com>");
        //     message.Bcc.Add(new MailAddress("Aethereal Systems <systems.ethereal@gmail.com>"));
        //     message.Subject = param["subject"].ToString();  
        //     message.Body = createEmailBody(param["user_email"].ToString(), param["template_content"].ToString());  
        //     message.IsBodyHtml = true;  
        //     using (var smtp = new SmtpClient())
        //     {
        //         await smtp.SendMailAsync(message);  
        //         await Task.FromResult(0);  
        //     }
        // }
        // private string createEmailBody(string user_name, string template_content)  
        // {  
        //     string body = string.Empty;  
        //     // using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))  
        //     // {
        //     //     body = reader.ReadToEnd();  
        //     // }  

        //     body = body.Replace("{user_name}", user_name);  
        //     body = body.Replace("{message}", template_content);  
        //     return body;  
        // } 
        [HttpPost("Send_Message", Name = "Send_Message")]
        public ActionResult Send_Message([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            try
            {
                dynamic dd = param;
                var senderEmail = new MailAddress("shinewanna27199@gmail.com");
                var receiverEmail = new MailAddress("shinewanna27199@gmail.com");
                var password = "Raindragon";
                var sub = dd.subject;
                var body = dd.template_content;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception ex)
            {
                string em = ex.Message;
            }
            return null;

        }
    }
}