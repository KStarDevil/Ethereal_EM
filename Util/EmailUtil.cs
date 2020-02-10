using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Max_Member_API
{
    public static class EmailUtil
    {
        public static async Task<dynamic> SendEmail(string ToEmails, string FromEmail, string subject, string message, Boolean ishtml, string Password, string SMTPUsername, string SMTPPassword, string HOST, int Port)
        {
            // if (FromEmail == "") FromEmail = emailAccount;
            // string SMTP = "smtp.gmail.com";
            // string SMTP = "email-smtp.us-east-1.amazonaws.com";
            // string SMTPUserName = "AKIAYHQOGYROLUW3AG7S";
            // string SMTPpassword = "BIVSutEe5ytV3tMeLQsuG8IjyMV118AwWyIjLOHJSYFz";
            // string fromEmail = "no-reply@maxenergy.com.mm";
            // string CONFIGSET = "ConfigSet";
            string FROMNAME = "MAX ENERGY";
            // string Password = "olmerlttizmmovbg";

            // int Port = 587;

            using (SmtpClient client = new SmtpClient(HOST, Port))  
            {
                try
                {
                //     client.Credentials =
                //     new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                    // SmtpClient client = new SmtpClient(SMTP, Port);
                    //     client.UseDefaultCredentials = false;
                    //     client.Credentials = new NetworkCredential(UserName, Password);
                        
                    //     MailMessage mailMessage = new MailMessage();
                    //     mailMessage.From = new MailAddress(FromEmail);
                    //     mailMessage.To.Add(ToEmails);
                    //     mailMessage.Body = message;
                    //     mailMessage.Subject = subject;
                    // client.Send(mailMessage);
                     
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(SMTPUsername, SMTPPassword);
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(FromEmail, FROMNAME);
                    //mailMessage.To.Add(ToEmail);
                    if (ToEmails != "")
                    {
                        ToEmails = ToEmails.Trim().Replace(",", ";");
                        string[] ToId = ToEmails.Split(';');

                        foreach (string ToEmail in ToId)
                        {
                            mailMessage.To.Add(ToEmail); //Adding Multiple email Id
                        }

                    }

                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = ishtml;
                    // mailMessage.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);
					
                    // if(MessageID!="")
					// mailMessage.Headers.Add("Message-Id", MessageID);
					
                    // await client.SendMailAsync(mailMessage).ConfigureAwait(false);
                    client.Send(mailMessage);

                }
                catch (Exception ex)
                {
                   
                //    return new { status = "fail", message = ex.Message +" "+ ex.StackTrace };
                    return new { status = "fail", message = "Oh! Something Wrong.Please try again!" };
                }
            }

            return new { status = "success", message = "" };
        }
    }
}
