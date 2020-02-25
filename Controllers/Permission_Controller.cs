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
            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic Post_Permission = _repositoryWrapper.Permission_Repository.GetAllPermission();

                if (Post_Permission == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Permission } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Permission } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Save_Permission", Name = "Save_Permission")]
        public dynamic Save_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        [HttpPost("Update_Permission", Name = "Update_Permission")]
        public dynamic Update_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Update Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        [HttpPost("Delete_Permission", Name = "Delete_Permission")]
        public dynamic Delete_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Delete Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }
    }
}