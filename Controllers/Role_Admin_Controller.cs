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
    public class Role_Admin_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Role_Admin_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Role_Admin", Name = "Get_Role_Admin")]
        public dynamic Get_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                dynamic PostData = _repositoryWrapper.Role_Admin_Repository.GetRoleAdmin();

                if (PostData == null)
                {
                    jsondata = new { status = 0, Message = "No Data", data = new { PostData } };
                }
                else
                {
                    jsondata = new { status = 1, Message = "Success", data = new { PostData } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }

        [HttpPost("Save_Role_Admin", Name = "Save_Role_Adminy")]
        public dynamic Save_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save = null;
            try
            {
                dynamic dd = param;
                int role_admin_id = dd.role_admin_id;
                int admin_id = dd.admin_id;
                int role_id = dd.role_id;

                tbl_role_admin c = new tbl_role_admin();

                c.role_admin_id = role_admin_id;
                c.admin_id = admin_id;
                c.role_id = role_id;

                _repositoryWrapper.Role_Admin_Repository.Create(c);

            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            save = new { status = 1, Message = "Save Successfully" };
            return save;
        }

        [HttpPost("Update_Role_Admin", Name = "Update_Role_Admin")]
        public dynamic Update_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Update = null;
            try
            {
                dynamic dd = param;
                int role_admin_id = dd.role_admin_id;
                int admin_id = dd.admin_id;
                int role_id = dd.role_id;

                
                dynamic main = _repositoryWrapper.Role_Admin_Repository.GetRoleAdminById(role_admin_id);
                tbl_role_admin rm = main as tbl_role_admin;

                rm.role_admin_id = role_admin_id;
                rm.admin_id = admin_id;
                rm.role_id = role_id;

                _repositoryWrapper.Role_Admin_Repository.Update(rm);

            }
            catch (Exception ex)
            {
                Update = new { status = 0, Message = ex.Message };
            }
            Update = new { status = 1, Message = "Update Successfully" };
            return Update;
        }

        [HttpPost("Delete_Role_Admin", Name = "Delete_Role_Admin")]
        public dynamic Delete_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Delete = null;
            try
            {
                dynamic dd = param;
                int role_admin_id = dd.role_admin_id;
                int admin_id = dd.admin_id;
                int role_id = dd.role_id;

                
                dynamic main = _repositoryWrapper.Role_Admin_Repository.GetRoleAdminById(role_admin_id);
                tbl_role_admin rm = main as tbl_role_admin;

                _repositoryWrapper.Role_Admin_Repository.Delete(rm);

            }
            catch (Exception ex)
            {
                Delete = new { status = 0, Message = ex.Message };
            }
            Delete = new { status = 1, Message = "Delete Successfully" };
            return Delete;
        }
    }
}