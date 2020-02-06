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
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostAdmin = _repositoryWrapper.Admin_Repository.GetAdmin();

                if (PostAdmin == null)
                {
                    jsondata = new { status = 0, Message = "No Data", data = new { PostAdmin } };
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

        [HttpPost("Save_Admin", Name = "Save_Admin")]
        public dynamic Save_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int admin_id = dd.admin_id;
                    string admin_name = dd.admin_name;
                    string admin_password = dd.admin_password;
                    string admin_photo = dd.admin_photo;

                    tbl_admin admin = new tbl_admin();

                    admin.admin_id = admin_id;
                    admin.admin_name = admin_name;
                    admin.admin_password = admin_password;
                    admin.admin_photo_path = admin_photo;

                    _repositoryWrapper.Admin_Repository.Create(admin);
                    result = new { status = 1, data = new { msg = "Save Successfully" } };
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

        [HttpPost("Update_Admin", Name = "Update_Admin")]
        public dynamic Update_Admin([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                    int admin_id = dd.admin_id;
                    string admin_name = dd.admin_name;
                    string admin_password = dd.admin_password;
                    string admin_photo = dd.admin_photo;


                    dynamic main = _repositoryWrapper.Admin_Repository.GetAdminbyid(admin_id);
                    tbl_admin admin = main as tbl_admin;

                    admin.admin_id = admin_id;
                    admin.admin_name = admin_name;
                    admin.admin_password = admin_password;
                    admin.admin_photo_path = admin_photo;

                    _repositoryWrapper.Admin_Repository.Update(admin);
                    result = new { status = 1, data = new { msg = "Update Successfully" } };
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
                result = new { status = 1, data = new { msg = "Delete Successfully" } };
            }
            catch (Exception ex)
            {
                result = new { status = 0, data = new { msg = ex.Message } };
            }
            return result;

        }
    }
}