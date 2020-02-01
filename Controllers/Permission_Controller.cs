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
    public class Permission_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Permission_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Permission", Name = "Get_Permission")]
        public dynamic Get_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostAdmin = _repositoryWrapper.Permission_Repository.GetAllPermission();
            
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

        [HttpPost("Save_Permission", Name = "Save_Permission")]
        public dynamic Save_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int permission_id = dd.permission_id;

                    string permission_name = dd.permission_name;
                    

                    tbl_permission permission = new tbl_permission();

                    permission.permission_id = permission_id;
                    permission.permission_name = permission_name;

                    _repositoryWrapper.Permission_Repository.Create(permission);
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

        [HttpPost("Update_Permission", Name = "Update_Permission")]
        public dynamic Update_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int permission_id = dd.permission_id;

                    string permission_name = dd.permission_name;

                  
                    dynamic main = _repositoryWrapper.Permission_Repository.GetPermissionbyid(permission_id);
                    tbl_permission permission = main as tbl_permission;

                    permission.permission_id = permission_id;
                    permission.permission_name = permission_name;
                    
                    _repositoryWrapper.Permission_Repository.Update(permission);
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

          [HttpPost("Delete_Permission", Name = "Delete_Permission")]
        public dynamic Delete_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int permission_id = dd.permission_id;

                    string permission_name = dd.permission_name;

                  
                    dynamic main = _repositoryWrapper.Permission_Repository.GetPermissionbyid(permission_id);
                    tbl_permission permission = main as tbl_permission;
                  
                    _repositoryWrapper.Permission_Repository.Delete(permission);
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