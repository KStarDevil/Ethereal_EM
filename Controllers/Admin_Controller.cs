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
using System.Threading.Tasks;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class Admin_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Admin_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Admin", Name = "Get_Admin")]
        public dynamic Get_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostAdmin = _repositoryWrapper.Admin_Repository.GetAdmin();

                if (PostAdmin == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { PostAdmin } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { PostAdmin } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Save_Admin", Name = "Save_Admin")]
        //[Authorize]
        public dynamic Save_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            // dynamic dd = param;
            // int id = dd.id;
            dynamic result = null;
            try
            {
                dynamic dd = param;
                string admin_name = dd.admin_name;
                string admin_email = dd.admin_email;
                int admin_role_id = dd.admin_role_id;
                string admin_login_name = dd.admin_login_name;
                string admin_password = dd.admin_password;
                string admin_photo = dd.admin_photo;
                string salt = Operational.Encrypt.SaltedHash.GenerateSalt();
                string password = Operational.Encrypt.SaltedHash.ComputeHash(salt, admin_password);
                tbl_admin admin = new tbl_admin();
                admin.admin_name = admin_name;
                admin.admin_password = password;
                admin.admin_salt = salt;
                admin.admin_email = admin_email;
                admin.admin_login_name = admin_name;
                admin.admin_role_id = admin_role_id;
                admin.admin_photo_path = admin_photo;
                admin.admin_created_date = DateTime.UtcNow;
                admin.admin_modified_date = DateTime.UtcNow;

                _repositoryWrapper.Admin_Repository.Create(admin);
                result = new { Status = 1, Message = "Save Success", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Failed", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        [HttpPost("Update_Admin", Name = "Update_Admin")]
        //[Authorize]
        public dynamic Update_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

                // dynamic dd = param;
                // int id = dd.id;
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int admin_id = dd.admin_id;
                    string admin_name = dd.admin_name;
                    string admin_login_name = dd.admin_login_name;
                    string admin_email = dd.admin_email;
                    string admin_password = dd.admin_password;
                    string admin_photo = dd.admin_photo;

                    dynamic main = _repositoryWrapper.Admin_Repository.GetAdminbyid(admin_id);
                    tbl_admin admin = main as tbl_admin;
                    if (!String.IsNullOrEmpty(admin_name))
                    {
                        admin.admin_name = admin_name;
                    }
                    if (!String.IsNullOrEmpty(admin_email))
                    {
                        admin.admin_email = admin_email;
                    }
                    if (!String.IsNullOrEmpty(admin_login_name))
                    {
                        admin.admin_login_name = admin_login_name;
                    }
                    if (!String.IsNullOrEmpty(admin_password))
                    {
                        string salt = Operational.Encrypt.SaltedHash.GenerateSalt();
                        string password = Operational.Encrypt.SaltedHash.ComputeHash(salt, admin_password);
                        admin.admin_password = password;
                        admin.admin_salt = salt;
                    }
                    if (dd.admin_role_id != null)
                    {
                        int admin_role_id = dd.admin_role_id;
                        admin.admin_role_id = admin_role_id;
                    }
                    if (!String.IsNullOrEmpty(admin_photo))
                    {
                        admin.admin_photo_path = admin_photo;
                    }
                    admin.admin_modified_date = DateTime.UtcNow;
                    _repositoryWrapper.Admin_Repository.Update(admin);
                    result = new { Status = 1, data = new { msg = "Update Successfully" } };
                }
                catch (Exception ex)
                {
                    result = new { Status = 0, data = new { msg = "Update Fail" } };
                    Console.WriteLine(ex.Message);
                }
                return result;
        }

        [HttpPost("Delete_Admin", Name = "Delete_Admin")]
        //[Authorize]
        public dynamic Delete_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            // dynamic dd = param;
            // int id = dd.id;
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int admin_id = dd.admin_id;
                string admin_name = dd.admin_name;
                string admin_password = dd.admin_password;
                string admin_photo = dd.admin_photo;


                dynamic main = _repositoryWrapper.Admin_Repository.GetAdminbyid(admin_id);
                tbl_admin admin = main as tbl_admin;

                _repositoryWrapper.Admin_Repository.Delete(admin);
                result = new { Status = 1, data = new { msg = "Delete Successfully" } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, data = new { msg = "Delete Fail" } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }
        [HttpPost("Mail_Send", Name = "Mail_Send")]
        public dynamic Mail_Send([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic dd = param;
            dynamic result = null;
            try
            {
                string toemail = dd.To_Mail;
                string subject = dd.Mail_Subject;
                string message = dd.Mail_Message;
                Boolean ishtml = dd.Mail_IsHTML;
                if (String.IsNullOrEmpty(toemail))
                {
                    result = new { Status = 0, Message = "Please Enter Receiver Mail" };
                }
                else
                {
                    var settingResultList = _repositoryWrapper.Setting.Get_Mail_Settings().ToList();
                    result = EmailUtil.Mail(settingResultList, toemail, subject, message, ishtml);
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Something went wrong!!" };
                Console.WriteLine(ex.Message);
            }
            return result;

        }
    }
}