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
    public class Menu_Permsiion_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Menu_Permsiion_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Menu_Permission", Name = "Get_Menu_Permission")]
        public dynamic Get_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                dynamic PostData = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermission();

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

        [HttpPost("Save_Menu_Permission", Name = "Save_Menu_Permission")]
        public dynamic Save_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save = null;
            try
            {
                dynamic dd = param;
                int menu_permission_id = dd.menu_permission_id;
                int menu_id = dd.menu_id;
                int permission_id = dd.permission_id;

                tbl_menu_permission mp = new tbl_menu_permission();

                mp.menu_permission_id = menu_permission_id;
                mp.menu_id = menu_id;
                mp.permission_id = permission_id;

                _repositoryWrapper.Menu_Permission_Repository.Create(mp);

            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            save = new { status = 1, Message = "Save Successfully" };
            return save;
        }

        [HttpPost("Update_Menu_Permission", Name = "Update_Menu_Permission")]
        public dynamic Update_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Update = null;
            try
            {
                dynamic dd = param;
                int menu_permission_id = dd.menu_permission_id;
                int menu_id = dd.menu_id;
                int permission_id = dd.permission_id;

                
                dynamic main = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermissionById(menu_permission_id);
                tbl_menu_permission mp = main as tbl_menu_permission;

                mp.menu_permission_id = menu_permission_id;
                mp.menu_id = menu_id;
                mp.permission_id = permission_id;

                _repositoryWrapper.Menu_Permission_Repository.Update(mp);

            }
            catch (Exception ex)
            {
                Update = new { status = 0, Message = ex.Message };
            }
            Update = new { status = 1, Message = "Update Successfully" };
            return Update;
        }

        [HttpPost("Delete_Menu_Permission", Name = "Delete_Menu_Permission")]
        public dynamic Delete_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Delete = null;
            try
            {
                dynamic dd = param;
                int menu_permission_id = dd.menu_permission_id;
                int menu_id = dd.menu_id;
                int permission_id = dd.permission_id;

                
                dynamic main = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermissionById(menu_permission_id);
                tbl_menu_permission mp = main as tbl_menu_permission;

                _repositoryWrapper.Menu_Permission_Repository.Delete(mp);

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