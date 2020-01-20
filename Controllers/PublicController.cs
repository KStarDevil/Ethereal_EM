using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;
using Ethereal_EM.Repository;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class PublicController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public PublicController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("UnLock", Name = "UnLock")]
         //[Authorize]
        public dynamic UnLock([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic AccountID = obj.adminID.ToString();
            dynamic objresponse;
            byte[] data = Convert.FromBase64String(AccountID);
            AccountID = Encoding.UTF8.GetString(data);
            int ID = Convert.ToInt32(AccountID);
            Admin objAdmin = _repositoryWrapper.Admin.FindByID(ID);
            if (objAdmin != null)
            {
                objAdmin.login_fail_count = 0;
                objAdmin.access_status = 0;
                _repositoryWrapper.Admin.Update(objAdmin);
                //_repositoryWrapper.Admin.Save();
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }
        /*  var AccountType = Convert.ToInt32(HttpContext.Request.Form["accountType"]);
         var returnval = false;

         if (AccountType == 1)//admin
         {
             try
             {
                 Admin objAdmin = _repositoryWrapper.Admin.FindByID(int.Parse(AccountID));
                 if (objAdmin != null)
                 {
                     objAdmin.login_fail_count = 0;
                     objAdmin.access_status = 0;
                     _repositoryWrapper.Admin.Update(objAdmin);

                     _repositoryWrapper.EventLog.Update(objAdmin);
                 }

                 returnval = true;
             }
             catch (Exception ex)
             {
                 _repositoryWrapper.EventLog.Error("", ex.Message);
                  returnval = false;
             }
         }
         else
         {
             returnval = false;
         } */

        /*  List<dynamic> dd = new List<dynamic>();
         dd.Add(returnval); */
        /*  dynamic objresponse = new { data = dd };
         return objresponse; */

        [HttpPost("ForgotPassword", Name = "ForgotPassword")]
      
        public dynamic ForgotPassword([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var LoginName = obj.loginName;//HttpContext.Request.Form["formDataObj1"];
            var accountType = obj.loginType;//HttpContext.Request.Form["formDataObj2"];

            var adminresult = (_repositoryWrapper.Admin.GetAdminByLoginName(LoginName.ToString()));
           
            //var aa=adminresult.ToList();
            if (adminresult.Count <= 0)
            {
                return new { data = false };
            }
            else
            {
                string ToEmail = adminresult[0].Email.ToString();
                string ID = adminresult[0].AdminID.ToString();
                string Account_Name = adminresult[0].AdminName.ToString();
                string salt = adminresult[0].Salt.ToString();
                string PWD = "";

                var emailtemplateresult = (_repositoryWrapper.EmailTemplate.GetEmailTemplate("Forgot Password Notification")).ToList();

                string Message = emailtemplateresult[0].template_content;
                string Subject = emailtemplateresult[0].subject;
                string Variable = emailtemplateresult[0].variable;
                string FromEmail = emailtemplateresult[0].from_email;

                var settingresult = (_repositoryWrapper.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;
                var Password = Operational.Cryptography.RandomPassword.Generate(int.Parse(pwdlength));

                if (Password != "" && Password.Length >= int.Parse(pwdlength))
                {
                    PWD = Operational.Encrypt.SaltedHash.ComputeHash(salt, Password);
                }

                var plainTextBytes = Encoding.UTF8.GetBytes(ID);
                ID = Convert.ToBase64String(plainTextBytes).Replace("=", "%3D");

                plainTextBytes = Encoding.UTF8.GetBytes(PWD);
                string enc_newpass = Convert.ToBase64String(plainTextBytes).Replace("=", "%3D");

                plainTextBytes = Encoding.UTF8.GetBytes(salt);
                string enc_salt = Convert.ToBase64String(plainTextBytes).Replace("=", "%3D");

                string reset_url ="#/forgotpassword/" + ID + "/" + enc_newpass + "/" + enc_salt;

                string body = Message.Replace("[Account Name]", Account_Name).Replace("[Account Email]", ToEmail).Replace("[Reset URL]", reset_url).Replace("[Generate Password]", Password).Replace("\n", "<br/>");

                var settingResultList = _repositoryWrapper.Setting.GetEmailSetting().ToList();
                bool result=Globalfunction.SendEmailAsync(settingResultList, ToEmail, FromEmail, Subject, body, true);
                // if(!isSuccess) _repositoryWrapper.EventLog.AddEventLog("Error", "Send Mail", ex.Message, "0", "0", "");
                return result;
            }
        }

        [HttpPost("resetpassword", Name = "resetpassword")]
        
        public dynamic resetpassword([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            string ID = obj.ID.ToString();//HttpContext.Request.Form["formDataObj1"];
            string accountType = obj.loginType.ToString();//HttpContext.Request.Form["formDataObj2"];
            string Password = obj.PWD.ToString();//HttpContext.Request.Form["formDataObj3"];
            string salt = obj.SALT.ToString();//HttpContext.Request.Form["formDataObj4"];
            int accountID;

            byte[] data = Convert.FromBase64String(ID);
            accountID = Convert.ToInt32(Encoding.UTF8.GetString(data));

            data = Convert.FromBase64String(Password);
            Password = Encoding.UTF8.GetString(data);

            data = Convert.FromBase64String(salt);
            salt = Encoding.UTF8.GetString(data);

            Admin objAdmin = _repositoryWrapper.Admin.FindByID(accountID);
            dynamic objresponse;
            objresponse = new { data = false };

            if (objAdmin != null)
            {
                objAdmin.Password = Password;
                _repositoryWrapper.Admin.Update(objAdmin);
                _repositoryWrapper.Admin.Save();
                 _repositoryWrapper.EventLog.Info("Success");

                objresponse = new { data = true };
            }

            return objresponse;
        }
       
    }
}