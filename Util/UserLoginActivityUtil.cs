using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace billing_api
{
    public static class UserLoginActivityUtil
    {
        // public static dynamic SendPasscodeEmail(Admin objUser, EmailTemplate objEmailTemplate, string passcode)
        // {
        //     try
        //     {
        //         if (objUser != null && objEmailTemplate != null)
        //         {
        //             string Message = objEmailTemplate.template_content;
        //             string Subject = objEmailTemplate.subject;
        //             string Variable = objEmailTemplate.variable;
        //             string FromEmail = objEmailTemplate.from_email;

        //             string Email = objUser.Email.ToString();
        //             string Account_Name = objUser.AdminName.ToString();
        //             string Login_Name = objUser.LoginName.ToString();

        //             var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objUser.AdminID.ToString());
        //             string ID = Convert.ToBase64String(plainTextBytes);
        //             string body = Message.Replace("[Account Name]", Account_Name).Replace("[PassCode]", passcode).Replace("\n", "<br/>");

        //             //bool flag = false;
        //             var result = EmailUtil.SendEmailAsync(Email, FromEmail, Subject, body, true).Result;

        //             return result;
        //         }

        //     }
        //     catch (Exception ex)
        //     {
        //         return new { status = "fail", message = ex.Message };
        //     }
        //     return new { status = "fail", message = "fail to send" };
        // }

        // public static dynamic SendAccountLockNotificationEmail(Admin objUser, EmailTemplate objEmailTemplate, string UnlockURL)
        // {
        //     try
        //     {
        //         if (objUser != null && objEmailTemplate != null)
        //         {
        //             string Message = objEmailTemplate.template_content;
        //             string Subject = objEmailTemplate.subject;
        //             string Variable = objEmailTemplate.variable;
        //             string FromEmail = objEmailTemplate.from_email;

        //             string Email = objUser.Email.ToString();
        //             string Account_Name = objUser.AdminName.ToString();
        //             string Login_Name = objUser.LoginName.ToString();

        //             var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objUser.AdminID.ToString());
        //             string ID = Convert.ToBase64String(plainTextBytes);
        //             string body = Message.Replace("[Unlock URL]", UnlockURL).Replace("[Account Name]", Account_Name).Replace("[Login Name]", Login_Name).Replace("\n", "<br/>");

        //             //bool flag = false;
        //             var result = EmailUtil.SendEmailAsync(Email, FromEmail, Subject, body, true).Result;

        //             return result;
        //         }

        //     }
        //     catch (Exception ex)
        //     {
        //         return new { status = "fail", message = ex.Message };
        //     }
        //     return new { status = "fail", message = "fail to send" };
        // }
    }
}
