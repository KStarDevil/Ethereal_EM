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

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class Role_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Role_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Role", Name = "Get_Role")]
        public dynamic Get_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostAdmin = _repositoryWrapper.Role_Repository.GetAllRole();
            
                if (PostAdmin == null)
                {
                    jsondata = new {  status = 0, Message = "No Data", data = new { PostAdmin } };
                }
                else
                {
                    jsondata = new { status = 1, Message = "Success", data = new { PostAdmin } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }

        [HttpPost("Save_Role", Name = "Save_Role")]
        public dynamic Save_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int role_id = dd.role_id;

                    string role_name = dd.role_name;
                    

                    tbl_role role = new tbl_role();

                    role.role_id = role_id;
                    role.role_name = role_name;

                    _repositoryWrapper.Role_Repository.Create(role);
                    result =  new { status = 1, data = new { msg ="Save Successfully" } };
                }
                catch (Exception ex)
                {
                    result = new { status = 0, data = new { msg = ex.Message } };
                }
                return result;
            }
            catch (Exception ex)
            {
                jsondata = new {status = 0, data = new { msg = ex.Message } };
            }
            return jsondata;
        }

        [HttpPost("Update_Role", Name = "Update_Role")]
        public dynamic Update_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int role_id = dd.role_id;

                    string role_name = dd.role_name;

                  
                    dynamic main = _repositoryWrapper.Role_Repository.GetRolebyid(role_id);
                    tbl_role role = main as tbl_role;

                    role.role_id = role_id;
                    role.role_name = role_name;
                    
                    _repositoryWrapper.Role_Repository.Update(role);
                    result =  new { status = 1, data = new { msg = "Update Successfully" } };
                }
                catch (Exception ex)
                {
                    result = new { status = 0, data = new { msg = ex.Message } };
                }
                return result;
            }
            catch (Exception ex)
            {
                jsondata = new { status = 0,data = new { msg = ex.Message } };
            }
            return jsondata;
        }

          [HttpPost("Delete_Role", Name = "Delete_Role")]
        public dynamic Delete_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int role_id = dd.role_id;

                    string role_name = dd.role_name;

                  
                    dynamic main = _repositoryWrapper.Role_Repository.GetRolebyid(role_id);
                    tbl_role role = main as tbl_role;
                  
                    _repositoryWrapper.Role_Repository.Delete(role);
                    result =  new { status = 1, data = new { msg = "Delete Successfully" } };
                }
                catch (Exception ex)
                {
                   result = new { status = 0, data = new { msg = ex.Message } };
                }
                return result;
            }
            catch (Exception ex)
            {
                jsondata = new { status = 0, data = new { msg = ex.Message } };
            }
            return jsondata;
        }
    }
}