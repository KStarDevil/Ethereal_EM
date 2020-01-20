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
    public class CustomerController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public CustomerController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllCustomerList", Name = "GetAllCustomerList")]
        [Authorize]
        public dynamic GetAllCustomerList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Customer.GetAllCustomerList(param);

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
        [HttpGet("GetTownshipCombo", Name = "GetTownshipCombo")]
        [Authorize]
        public dynamic GetTownshipCombo()
        {
            var query = _repositoryWrapper.General.GetTownshipCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetTownshipComboEvent/{ID}", Name = "GetTownshipComboEvent")]
        [Authorize]
        public dynamic GetTownshipComboEvent(int ID)
        {
            var query = _repositoryWrapper.Company.GetTownshipList(ID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetStateCombo", Name = "GetStateCombo")]
        [Authorize]
        public dynamic GetStateCombo()
        {
            var query = _repositoryWrapper.General.GetStateList();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetProduct", Name = "GetProduct")]
        [Authorize]
        public dynamic GetProduct()
        {
            var query = _repositoryWrapper.Customer.GetProduct();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpPost("CheckDuplicateCustomer", Name = "CheckDuplicateCustomer")]
        [Authorize]
        public dynamic CheckDuplicateCustomer([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int customerID = obj.CustomerID != null ? obj.CustomerID : 0;
            string code = obj.code;
            string username = obj.username;
            string Email = obj.Email;
            string Phone = obj.Phone;

            var duplicatedCode = _repositoryWrapper.Customer.CheckDuplicateCode(customerID, code);
            var duplicateusername = _repositoryWrapper.Customer.CheckDuplicateUserName(customerID, username);
            var duplicatedEmail = _repositoryWrapper.Customer.CheckDuplicateEmail(customerID, Email);
            var duplicatedPhone = _repositoryWrapper.Customer.CheckDuplicatePhone(customerID, Phone);
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
        [HttpGet("GetCustomerData/{CustomerID}", Name = "GetCustomerData")]
        [Authorize]
        public dynamic GetCustomerData(int CustomerID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Customer.GetCustomerData(CustomerID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        [HttpGet("GetStorageCharges/{CustomerID}", Name = "GetStorageCharges")]
        [Authorize]
        public dynamic GetStorageCharges(int CustomerID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.StorageCharges.GetStorageCharges(CustomerID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        [HttpPost("SaveCustomer", Name = "SaveCustomer")]
        [Authorize]
        public dynamic SaveCustomer([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int CustomerID = obj.CustomerID != null ? obj.CustomerID : 0;
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var cusobj = _repositoryWrapper.Customer.FindByID(CustomerID);
                if (cusobj != null)
                {
                    cusobj.customername = obj.name;
                    cusobj.code = obj.code;
                    cusobj.username = obj.username;
                    cusobj.email = obj.Email;
                    cusobj.township = obj.TownshipID;
                    cusobj.state = obj.StateID;
                    cusobj.address = obj.Address;
                    cusobj.phone = obj.Phone;
                    cusobj.modifieddate = System.DateTime.Now;
                    cusobj.inactive = true;
                    _repositoryWrapper.Customer.Update(cusobj);
                    _repositoryWrapper.EventLog.Update(cusobj);

                }
                else
                {
                    var newobj = new Customer();
                    newobj.customername = obj.name;
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
                    if (password.ToString().Length < int.Parse(pwdlength))
                    {
                        CustomerID = -3;
                    }
                    else
                    {
                        string salt = Operational.Encrypt.SaltedHash.GenerateSalt();
                        password = Operational.Encrypt.SaltedHash.ComputeHash(salt, password.ToString());
                        newobj.password = password;
                        newobj.salt = salt;
                        _repositoryWrapper.Customer.Create(newobj);
                        _repositoryWrapper.Customer.Save();

                    }
                    CustomerID = newobj.customerID;
                    _repositoryWrapper.EventLog.Insert(newobj);
                }
                objresponse = new { data = CustomerID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Customer Controller/ Save Customer", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }
        [HttpPost("SaveStorageCharges", Name = "SaveStorageCharges")]
        [Authorize]
        public dynamic SaveStorageCharges([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            bool result = true;
            dynamic objresponse;

            for (int i = 0; i < obj.data.Count; i++)
            {
                int storageChargesID = obj.data[i].ID == null ? 0 : obj.data[i].ID;
                var objCharge = _repositoryWrapper.StorageCharges.FindByID(storageChargesID);
                if (objCharge != null)
                {
                    objCharge.customerID = obj.CustomerID;
                    objCharge.productID = obj.data[i].ProductID;
                    objCharge.charges = obj.data[i].Price;
                    objCharge.modifieddate = System.DateTime.Now;
                    objCharge.inactive = true;
                    _repositoryWrapper.StorageCharges.Update(objCharge);
                    _repositoryWrapper.EventLog.Insert(objCharge);
                }
                else
                {
                    var newobj = new StorageCharges();
                    newobj.customerID = obj.CustomerID;
                    newobj.productID = obj.data[i].ProductID;
                    newobj.charges = obj.data[i].Price;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.StorageCharges.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);
                }
            }
            objresponse = new { data = result };
            return objresponse;
        }
        [HttpDelete("DeleteCustomer/{CustomerID}", Name = "DeleteCustomer")]
        [Authorize]
        public dynamic DeleteCustomer(int CustomerID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.Customer.FindByID(CustomerID);
                newobj.inactive = false;
                _repositoryWrapper.Customer.Update(newobj);
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
        [HttpGet("unBlockCustomer/{CustomerID}", Name = "unBlockCustomer")]
        [Authorize]
        public dynamic unBlockCustomer(int CustomerID)
        {
            var objCustomer = _repositoryWrapper.Customer.FindByID(CustomerID);
            dynamic objresponse;

            if (objCustomer != null)
            {
                objCustomer.login_fail_count = 0;
                objCustomer.access_status = 0;
                _repositoryWrapper.Customer.Update(objCustomer);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }
        [HttpGet("BlockCustomer/{CustomerID}", Name = "BlockCustomer")]
        [Authorize]
        public dynamic BlockCustomer(int CustomerID)
        {
            var objCustomer = _repositoryWrapper.Customer.FindByID(CustomerID);
            dynamic objresponse;

            if (objCustomer != null)
            {
                objCustomer.login_fail_count = 6;
                objCustomer.access_status =2;
                _repositoryWrapper.Customer.Update(objCustomer);
                objresponse = new { data = true };
                _repositoryWrapper.EventLog.Info("Success");
            }
            else
                objresponse = new { data = false };
            return objresponse;
        }

        [HttpGet("CustomerResetPassword/{CustomerID}", Name = "CustomerResetPassword")]
        [Authorize]
        public dynamic CustomerResetPassword(int CustomerID)
        {
            Customer objCustomer = _repositoryWrapper.Customer.FindByID(CustomerID);
            string Password = "";
            string salt = "";
            string PWD = "";
            dynamic objresponse;
            objresponse = new { data = false };

            if (objCustomer != null)
            {
                //Password = "gwtsoft1"; //Operational.Cryptography.RandomPassword.Generate();
                var settingresult = (_repositoryWrapper.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;
                Password = Operational.Cryptography.RandomPassword.Generate(int.Parse(pwdlength));

                if (Password != "" && Password.Length >= int.Parse(pwdlength))
                {
                    salt = objCustomer.salt;
                    PWD = Operational.Encrypt.SaltedHash.ComputeHash(salt, Password);
                    objCustomer.password = PWD;
                    _repositoryWrapper.Customer.Update(objCustomer);

                    _repositoryWrapper.EventLog.Info("Success");
                    objresponse = new { data = Password };
                }
            }

            return objresponse;
        }
    }
}