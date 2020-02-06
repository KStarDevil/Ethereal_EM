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
        [HttpGet("Get_Admin", Name = "Get_Admin")]
        public dynamic Get_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic Admin_Data = _repositoryWrapper.Admin_Repository.GetAdmin();

                if (Admin_Data == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Admin_Data } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Admin_Data } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("Save_Admin", Name = "Save_Admin")]
        public dynamic Save_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

                // dynamic dd = param;
                // int id = dd.id;
                dynamic result = null;
            try
            {
                dynamic dd = param;
                int admin_id = dd.admin_id;
                string admin_name = dd.admin_name;
                string admin_password = dd.admin_password;
                string admin_photo = dd.admin_photo;

                tbl_admin admin = new tbl_admin();

                admin.admin_id = admin_id;
                admin.admin_name = admin_name;
                admin.admin_password = admin_password;
                admin.admin_photo = admin_photo;

                _repositoryWrapper.Admin_Repository.Create(admin);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("Update_Admin", Name = "Update_Admin")]
        public dynamic Update_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int admin_id = dd.admin_id;
                    string admin_name = dd.admin_name;
                    string admin_password = dd.admin_password;
                    string admin_photo = dd.admin_photo;


                    dynamic main = _repositoryWrapper.Admin_Repository.GetAdminbyid(admin_id);
                    tbl_admin admin = main as tbl_admin;

                    admin.admin_id = admin_id;
                    admin.admin_name = admin_name;
                    admin.admin_password = admin_password;
                    admin.admin_photo = admin_photo;

                    _repositoryWrapper.Admin_Repository.Update(admin);
                    result = new { Status = 1, Message = "Update Successfully", data = new { } };
                }
                catch (Exception ex)
                {
                    result = new { Status = 0, Message = ex.Message, data = new { } };
                }
                return result;
        }

        [HttpPost("Delete_Admin", Name = "Delete_Admin")]
        public dynamic Delete_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            // dynamic dd = param;
            // int id = dd.id;
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int admin_id = dd.admin_id;
                string admin_name = dd.admin_name;
                string admin_password = dd.admin_password;
                string admin_photo = dd.admin_photo;


                dynamic main = _repositoryWrapper.Admin_Repository.GetAdminbyid(admin_id);
                tbl_admin admin = main as tbl_admin;

                _repositoryWrapper.Admin_Repository.Delete(admin);
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