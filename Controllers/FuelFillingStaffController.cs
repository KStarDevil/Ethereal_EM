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
    public class FuelFillingStaffController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public FuelFillingStaffController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllStaffList", Name = "GetAllStaffList")]
        [Authorize]
        public dynamic GetAllStaffList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.FuelFillingStaff.GetAllStaffList(param);

            if (mainQuery == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
            {
                objresponse = new { data = mainQuery.Data, total = mainQuery.Total };
            }
            return objresponse;
        }
        [HttpGet("GetTownshipStaff", Name = "GetTownshipStaff")]
        [Authorize]
        public dynamic GetTownshipStaff()
        {
            var query = _repositoryWrapper.General.GetTownshipCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetTownshipStaffEvent/{ID}", Name = "GetTownshipStaffEvent")]
        [Authorize]
        public dynamic GetTownshipStaffEvent(int ID)
        {
            var query = _repositoryWrapper.Company.GetTownshipList(ID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetStateComboStaff", Name = "GetStateComboStaff")]
        [Authorize]
        public dynamic GetStateComboStaff()
        {
            var query = _repositoryWrapper.General.GetStateList();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
       
        [HttpPost("CheckDuplicateStaff", Name = "CheckDuplicateStaff")]
        [Authorize]
        public dynamic CheckDuplicateStaff([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int staffID = obj.StaffID != null ? obj.StaffID : 0;
            string code = obj.code;
            string username = obj.username;
            string Email = obj.Email;
            string Phone = obj.Phone;

            var duplicatedCode = _repositoryWrapper.FuelFillingStaff.CheckDuplicateCode(staffID, code);
            var duplicateusername = _repositoryWrapper.FuelFillingStaff.CheckDuplicateUserName(staffID, username);
            var duplicatedEmail = _repositoryWrapper.FuelFillingStaff.CheckDuplicateEmail(staffID, Email);
            var duplicatedPhone = _repositoryWrapper.FuelFillingStaff.CheckDuplicatePhone(staffID, Phone);
            objresult = new
            {
                Code = duplicatedCode > 0 ? 1 : 0,
                UserName = duplicateusername > 0 ? 1 : 0,
                Email = duplicatedEmail > 0 ? 1 : 0,
                Phone = duplicatedPhone > 0 ? 1 : 0
            };

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }
        [HttpGet("GetStaffData/{StaffID}", Name = "GetStaffData")]
        [Authorize]
        public dynamic GetStaffData(int StaffID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.FuelFillingStaff.GetStaffData(StaffID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        
        [HttpPost("SaveStaff", Name = "SaveStaff")]
        [Authorize]
        public dynamic SaveStaff([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int StaffID = obj.StaffID != null ? obj.StaffID : 0;
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var cusobj = _repositoryWrapper.FuelFillingStaff.FindByID(StaffID);
                if (cusobj != null)
                {
                    cusobj.staffname = obj.name;
                    cusobj.code = obj.code;
                    cusobj.username = obj.username;
                    cusobj.email = obj.Email;
                    cusobj.township = obj.TownshipID;
                    cusobj.state = obj.StateID;
                    cusobj.address = obj.Address;
                    cusobj.phone = obj.Phone;
                    cusobj.modifieddate = System.DateTime.Now;
                    cusobj.inactive = true;
                    _repositoryWrapper.FuelFillingStaff.Update(cusobj);
                    _repositoryWrapper.EventLog.Update(cusobj);

                }
                else
                {
                    var newobj = new FuelFillingStaff();
                    newobj.staffname = obj.name;
                    newobj.code = obj.code;
                    newobj.username = obj.username;
                    newobj.email = obj.Email;
                    newobj.township = obj.TownshipID;
                    newobj.state = obj.StateID;
                    newobj.address = obj.Address;
                    newobj.phone = obj.Phone;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    newobj.access_status = 0;
                    var password = obj.Password;
                    var settingresult = _repositoryWrapper.Setting.GetPasswordValidation().ToList();
                    var pwdlength = settingresult[0].Value;
                    /* if (password.ToString().Length < int.Parse(pwdlength))
                    {
                        StaffID = -3;
                    } */
                   /*  else
                    { */
                        string salt = Operational.Encrypt.SaltedHash.GenerateSalt();
                        password = Operational.Encrypt.SaltedHash.ComputeHash(salt, password.ToString());
                        newobj.password = password;
                        newobj.salt = salt;
                        _repositoryWrapper.FuelFillingStaff.Create(newobj);
                        _repositoryWrapper.FuelFillingStaff.Save();

                    //}
                    StaffID = newobj.staffID;
                    _repositoryWrapper.EventLog.Insert(newobj);
                }
                objresponse = new { data = StaffID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Customer Controller/ Save Customer", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }
       
        [HttpDelete("DeleteStaff/{StaffID}", Name = "DeleteStaff")]
        [Authorize]
        public dynamic DeleteStaff(int StaffID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.FuelFillingStaff.FindByID(StaffID);
                newobj.inactive = false;
                _repositoryWrapper.FuelFillingStaff.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { ex.Message };
            }
            objresponse = new { data = result };
            return objresponse;
        }
        [HttpGet("unBlockStaff/{StaffID}", Name = "unBlockStaff")]
        [Authorize]
        public dynamic unBlockCustomer(int StaffID)
        {
            var objStaff = _repositoryWrapper.FuelFillingStaff.FindByID(StaffID);
            dynamic objresponse;

            if (objStaff != null)
            {
                objStaff.login_fail_count = 0;
                objStaff.access_status = 0;
                _repositoryWrapper.FuelFillingStaff.Update(objStaff);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }
        [HttpGet("BlockStaff/{StaffID}", Name = "BlockStaff")]
        [Authorize]
        public dynamic BlockStaff(int StaffID)
        {
            var objStaff = _repositoryWrapper.FuelFillingStaff.FindByID(StaffID);
            dynamic objresponse;

            if (objStaff != null)
            {
                objStaff.login_fail_count = 6;
                objStaff.access_status =2;
                _repositoryWrapper.FuelFillingStaff.Update(objStaff);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }

        [HttpGet("StaffResetPassword/{StaffID}", Name = "StaffResetPassword")]
        [Authorize]
        public dynamic StaffResetPassword(int StaffID)
        {
            FuelFillingStaff objStaff = _repositoryWrapper.FuelFillingStaff.FindByID(StaffID);
            string Password = "";
            string salt = "";
            string PWD = "";
            dynamic objresponse;
            objresponse = new { data = false };

            if (objStaff != null)
            {
                //Password = "gwtsoft1"; //Operational.Cryptography.RandomPassword.Generate();
                var settingresult = (_repositoryWrapper.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;
                Password = Operational.Cryptography.RandomPassword.Generate(int.Parse(pwdlength));

                if (Password != "")
                {
                    salt = objStaff.salt;
                    PWD = Operational.Encrypt.SaltedHash.ComputeHash(salt, Password);
                    objStaff.password = PWD;
                    _repositoryWrapper.FuelFillingStaff.Update(objStaff);

                    _repositoryWrapper.EventLog.Info("Success");
                    objresponse = new { data = Password };
                }
            }

            return objresponse;
        }
    }
}