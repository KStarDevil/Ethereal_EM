using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.ComponentModel.DataAnnotations;


namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class AdminController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public AdminController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("GetAdminList", Name = "GetAdminList")]
        [Authorize]
        public dynamic GetAdminList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            DataSourceResult dsmainQuery = _repositoryWrapper.Admin.GetAdmins(param); // admin table + state 
            dynamic objresponse = null;
            if (dsmainQuery == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
            {
                objresponse = new { data = dsmainQuery.Data, total = dsmainQuery.Total };
            }
            return objresponse;
        }

        [HttpPost("GetAdminSetup/{AdminID}", Name = "GetAdminSetup")]
        [Authorize]
        public dynamic GetAdminSetup(int AdminID)
        {
            var Active = HttpContext.Request.Form["Active"];
            var Blocked = HttpContext.Request.Form["Blocked"];
            var mainQuery = _repositoryWrapper.Admin.FindAll();
            if (AdminID != 0)
            {
                mainQuery = mainQuery.Where(x => x.AdminID == AdminID);
            }

            if (Active == "true" && Blocked == "false")
            {
                var myInClause1 = new sbyte[] { 0 };
                mainQuery = mainQuery.Where(x => myInClause1.Contains(x.access_status));
            }
            else if (Active == "false" && Blocked == "true")
            {
                var myInClause1 = new sbyte[] { 1, 2 };
                mainQuery = mainQuery.Where(x => myInClause1.Contains(x.access_status));
            }
            else if (Active == "false" && Blocked == "false")
            {
                var myInClause1 = new sbyte[] { 1 };
                mainQuery = mainQuery.Where(x => myInClause1.Contains(x.access_status));
            }
            else
            {
                var myInClause2 = new sbyte[] { 0, 2 };
                mainQuery = mainQuery.Where(x => myInClause2.Contains(x.access_status));
            }
            dynamic objresponse = new { data = mainQuery.ToList() };
            return objresponse;
        }


        [HttpGet("GetAdminComboData", Name = "GetAdminComboData")]
        [Authorize]
        public dynamic GetAdminComboData()
        {
            var adminLevel = _repositoryWrapper.AdminLevel.FindAll();
            dynamic objresponse = new { adminLevel = adminLevel };
            return objresponse;
        }


        [HttpPost("checkDuplicate", Name = "AdmincheckDuplicate")]
        [Authorize]
        public dynamic checkDuplicate([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int AdminID = obj.AdminID != null ? obj.AdminID : 0;
            string AdminName = obj.AdminName;
            string LoginName = obj.LoginName;
            string nrc = obj.nrc;

            var duplicateName = _repositoryWrapper.Admin.CheckDuplicateAdminName(AdminID, AdminName);
            var duplicateLoginName = _repositoryWrapper.Admin.CheckDuplicateAdminLoginName(AdminID, LoginName);

            objresult = new
            {
                name = duplicateName > 0 ? 1 : 0,
                loginName = duplicateLoginName > 0 ? 1 : 0,
            };

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }

        [HttpPost("AddAdminSetup", Name = "AddAdminSetup")]
        [Authorize]
        public dynamic AddAdminSetup([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;

            int AdminID = obj.AdminID != null ? obj.AdminID : 0;
            string Admin = obj.Admin;
            string CompanyID = _tokenData.CompanyID;
            var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            if (objAdmin != null)
            {
                string AdminName = obj.AdminName;
                int AdminLevelID = obj.AdminLevelID;
                string LoginName = obj.LoginName;
                string Email = obj.Email;
                objAdmin.AdminName = AdminName;
                objAdmin.AdminLevelID = AdminLevelID;
                objAdmin.LoginName = LoginName;
                objAdmin.Email = Email;
                objAdmin.CompanyID = CompanyID;
                _repositoryWrapper.Admin.Update(objAdmin);
                _repositoryWrapper.Admin.Save();
                _repositoryWrapper.EventLog.Update(objAdmin);
            }
            else
            {
                try
                {
                    var newobj = new Admin();
                    newobj.AdminName = obj.AdminName;
                    newobj.AdminLevelID = obj.AdminLevelID;
                    newobj.LoginName = obj.LoginName;
                    newobj.Email = obj.Email;
                    newobj.CompanyID = CompanyID;
                    newobj.access_status = 0;
                    newobj.created_date = System.DateTime.Now;
                    newobj.modified_date = System.DateTime.Now;
                    var password = obj.Password;
                    var settingresult = _repositoryWrapper.Setting.GetPasswordValidation().ToList();
                    var pwdlength = settingresult[0].Value;

                    if (password.ToString().Length < int.Parse(pwdlength))
                    {
                        AdminID = -3;
                    }
                    else
                    {
                        string salt = Operational.Encrypt.SaltedHash.GenerateSalt();
                        password = Operational.Encrypt.SaltedHash.ComputeHash(salt, password.ToString());
                        newobj.Password = password;
                        newobj.Salt = salt;
                        _repositoryWrapper.Admin.Create(newobj);
                        _repositoryWrapper.Admin.Save();

                    }
                    AdminID = newobj.AdminID;
                    _repositoryWrapper.EventLog.Insert(newobj);
                }
                catch (ValidationException vex)
                {
                    _repositoryWrapper.EventLog.Error("Admin Controller/ AddAdminSetup", vex.Message);
                    objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                    return objresponse;
                }
            }
            objresponse = new { data = AdminID };
            return objresponse;
        }

        [HttpGet("ResetPassword/{AdminID}", Name = "AdminResetPassword")]
        [Authorize]
        public dynamic ResetPassword(int AdminID)
        {
            Admin objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            string Password = "";
            string salt = "";
            string PWD = "";
            dynamic objresponse;
            objresponse = new { data = false };

            if (objAdmin != null)
            {
                //Password = "gwtsoft1"; //Operational.Cryptography.RandomPassword.Generate();
                var settingresult = (_repositoryWrapper.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;
                Password = Operational.Cryptography.RandomPassword.Generate(int.Parse(pwdlength));

                if (Password != "" && Password.Length >= int.Parse(pwdlength))
                {
                    salt = objAdmin.Salt;
                    PWD = Operational.Encrypt.SaltedHash.ComputeHash(salt, Password);
                    objAdmin.Password = PWD;
                    _repositoryWrapper.Admin.Update(objAdmin);

                    _repositoryWrapper.EventLog.Info("Success");
                    objresponse = new { data = Password };
                }
            }

            return objresponse;
        }

        [HttpPost("checkPassword", Name = "checkPassword")]
        [Authorize]
        public dynamic checkPassword([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            string oldPwd = (string)obj.oldPassword;
            int AdminID = int.Parse(_tokenData.UserID);

            var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            dynamic objresponse;

            if (objAdmin != null)
            {
                string oldhash = objAdmin.Password;
                string oldsalt = objAdmin.Salt;
                bool flag = Operational.Encrypt.SaltedHash.Verify(oldsalt, oldhash, oldPwd);
                objresponse = new { data = flag };
            }
            else
                objresponse = new { data = false };

            return objresponse;
        }

        [HttpPost("PassChange", Name = "PassChange")]
        [Authorize]
        public dynamic PassChange([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            int AdminID = int.Parse(_tokenData.UserID);
            dynamic obj = param;
            string oldPassword = obj.oldPassword;
            string Password = obj.newPassword;

            var settingresult = (_repositoryWrapper.Setting.GetPasswordValidation()).ToList();
            var pwdlength = settingresult[0].Value;
            dynamic objresponse;
            objresponse = new { data = false };

            if (Password.ToString().Length >= int.Parse(pwdlength))
            {
                Admin objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
                string salt = "";
                string PWD = "";

                if (objAdmin != null)
                {
                    salt = objAdmin.Salt;
                    string oldhash = objAdmin.Password;
                    bool flag = Operational.Encrypt.SaltedHash.Verify(salt, oldhash, oldPassword);
                    if (flag)
                    {
                        PWD = Operational.Encrypt.SaltedHash.ComputeHash(salt, Password);
                        objAdmin.Password = PWD;
                        _repositoryWrapper.Admin.Update(objAdmin);
                        _repositoryWrapper.Admin.Save();
                        _repositoryWrapper.EventLog.Info("Success");
                        objresponse = new { data = true };
                    }
                }
            }

            return objresponse;
        }

        [HttpGet("unBlock/{AdminID}", Name = "unBlock")]
        [Authorize]
        public dynamic unBlock(int AdminID)
        {
            var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            dynamic objresponse;

            if (objAdmin != null)
            {
                objAdmin.login_fail_count = 0;
                objAdmin.access_status = 0;
                _repositoryWrapper.Admin.Update(objAdmin);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }

        [HttpGet("Block/{AdminID}", Name = "Block")]
        [Authorize]
        public dynamic Block(int AdminID)
        {
            var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            dynamic objresponse;

            if (objAdmin != null)
            {
                objAdmin.login_fail_count = 6;
                objAdmin.access_status = 2;
                _repositoryWrapper.Admin.Update(objAdmin);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }

        [HttpPost("SaveImagePath", Name = "AdminSaveImagePath")]
        [Authorize]
        public dynamic SaveImagePath([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;

            int AdminID = Convert.ToInt32(obj.ID.Value);
            string FileName = obj.FileName.Value;
            string ext = obj.FileName.Value.Replace(".", "");
            string ImagePath = AdminID.ToString() + '.' + ext;
            var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
            dynamic objresponse;

            if (objAdmin != null)
            {
                objAdmin.ImagePath = ImagePath;
                _repositoryWrapper.Admin.Update(objAdmin);
                _repositoryWrapper.EventLog.Update(objAdmin);
                objresponse = new { data = true };
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }

        [HttpDelete("DeleteAdminSetup/{AdminID}", Name = "DeleteAdminSetup")]
        [Authorize]
        public dynamic DeleteAdminSetup(int AdminID)
        {
            bool retBool = false;

            //validateDelete
            var userresult = (_repositoryWrapper.EventLog.GetEventLogByUser(AdminID, "admin")).ToList();
            if (userresult.Count != 0)
            {
                retBool = false;
            }
            else
            {
                var objAdmin = _repositoryWrapper.Admin.FindByID(AdminID);
                if (objAdmin != null)
                {
                    _repositoryWrapper.Admin.Delete(objAdmin);
                    retBool = true;
                    _repositoryWrapper.EventLog.Delete(objAdmin);
                }
            }
            dynamic objresponse = new { data = retBool };
            return objresponse;
        }
    }
}