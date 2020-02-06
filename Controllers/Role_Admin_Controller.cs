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
            dynamic result = null;
            try
            {
                dynamic Post_Role_Amin = _repositoryWrapper.Role_Admin_Repository.GetRoleAdmin();

                if (Post_Role_Amin == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Role_Amin } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Role_Amin } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("Save_Role_Admin", Name = "Save_Role_Adminy")]
        public dynamic Save_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            
            return result;
        }

        [HttpPost("Update_Role_Admin", Name = "Update_Role_Admin")]
        public dynamic Update_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            
            return result;
        }

        [HttpPost("Delete_Role_Admin", Name = "Delete_Role_Admin")]
        public dynamic Delete_Role_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int role_admin_id = dd.role_admin_id;
                int admin_id = dd.admin_id;
                int role_id = dd.role_id;

                
                dynamic main = _repositoryWrapper.Role_Admin_Repository.GetRoleAdminById(role_admin_id);
                tbl_role_admin rm = main as tbl_role_admin;

                _repositoryWrapper.Role_Admin_Repository.Delete(rm);
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            
            return result;
        }
    }
}