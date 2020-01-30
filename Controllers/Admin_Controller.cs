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
    public class Admin_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Admin_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Admin_Permission", Name = "Get_Admin_Permission")]
        public dynamic Get_Admin_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostAdmin = _repositoryWrapper.Permission_Admin_Repository.GetPermissionAdmin();
            
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

        [HttpPost("Save_Admin_Permission", Name = "Save_Admin_Permission")]
        public dynamic Save_Admin_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int adminid = dd.admin_id;
                    int permissionid = dd.permission_id;

                    tbl_permission_admin permisson_admin = new tbl_permission_admin();
                    permisson_admin.admin_id = adminid;
                    permisson_admin.permission_id = permissionid;
                    _repositoryWrapper.Permission_Admin_Repository.Create(permisson_admin);
                    result = "Save Successfully";
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

        [HttpPost("Update_Admin_Permission", Name = "Update_Admin_Permission")]
        public dynamic Update_Admin_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int adminid = dd.admin_id;
                    int permission_admin_id = dd.permission_admin_id;
                    int permissionid = dd.permission_id;

                  
                    dynamic main = _repositoryWrapper.Permission_Admin_Repository.GetPermissionAdminByID(permission_admin_id);
                    tbl_permission_admin permisson_admin = main as tbl_permission_admin;
                    permisson_admin.admin_id = adminid;
                    permisson_admin.permission_admin_id = permission_admin_id;
                    permisson_admin.permission_id = permissionid;
                    _repositoryWrapper.Permission_Admin_Repository.Update(permisson_admin);
                    result = "Update Successfully";
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

          [HttpPost("Delete_Admin_Permission", Name = "Delete_Admin_Permission")]
        public dynamic Delete_Admin_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int adminid = dd.admin_id;
                    int permission_admin_id = dd.permission_admin_id;
                    int permissionid = dd.permission_id;

                  
                    dynamic main = _repositoryWrapper.Permission_Admin_Repository.GetPermissionAdminByID(permission_admin_id);
                    tbl_permission_admin permisson_admin = main as tbl_permission_admin;
                  
                    _repositoryWrapper.Permission_Admin_Repository.Delete(permisson_admin);
                    result = "Delete Successfully";
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