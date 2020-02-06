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
            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic Post_Role = _repositoryWrapper.Role_Repository.GetAllRole();

                if (Post_Role == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Role } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Role } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("Save_Role", Name = "Save_Role")]
        public dynamic Save_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;

        }

        [HttpPost("Update_Role", Name = "Update_Role")]
        public dynamic Update_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;


        }

        [HttpPost("Delete_Role", Name = "Delete_Role")]
        public dynamic Delete_Role([FromBody] Newtonsoft.Json.Linq.JObject param)
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