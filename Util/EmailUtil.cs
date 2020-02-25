using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;


namespace Ethereal_EM
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
            string FROMNAME = "Aethereal Systems";
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
                    Console.WriteLine(ex.Message);
                    //    return new { status = "fail", message = ex.Message +" "+ ex.StackTrace };
                    return new { status = "fail", message = "Oh! Something Wrong.Please try again!" };
                }
            }

            return new { status = "success", message = "" };
        }

        public static dynamic Mail(List<Setting> settingresult, string toemail, string subject, string message, Boolean ishtml)
        {
            string msg = "Success";
            string SMTP = "";
            string From_Mail = "";
            string From_Mail_Name = "";
            string From_Mail_Password = "";
            int Port = 0;//Convert.ToInt32(settingresult[3].Value);
            dynamic return_data = new { Status = 1, Message = "Mail Sent" };

            foreach (var s in settingresult)
            {
                if (s.Name.Equals("SMTP"))
                    SMTP = s.Value;

                if (s.Name.Equals("Email"))
                    From_Mail = s.Value;

                if (s.Name.Equals("Email_Password"))
                    From_Mail_Password = s.Value;

                if (s.Name.Equals("Email_Name"))
                    From_Mail_Name = s.Value;

                if (s.Name.Equals("Server_Port"))
                    Port = Convert.ToInt32(s.Value);
            }
            try
            {
                // string frommaiaddress = From_Mail;
                var fromAddress = new MailAddress(From_Mail, From_Mail_Name);
                var toAddress = new MailAddress(toemail, "");
                // string fromPassword = From_Mail_Password;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = fromAddress;
                    mail.To.Add(toAddress);
                    mail.Subject = subject;
                    if (ishtml == true)
                    {
                        mail.Body = "<h1>" + message + "</h1>";
                        mail.IsBodyHtml = true;
                    }
                    else
                    {
                        mail.Body = message;
                        mail.IsBodyHtml = false;
                    }
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", Port))
                    {
                        smtp.Credentials = new NetworkCredential(From_Mail, From_Mail_Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                return_data = new { Status = 0, Message = "Something Went Wrong" };
                msg = ex.Message;
            }
            return return_data;
        }
    }
}
