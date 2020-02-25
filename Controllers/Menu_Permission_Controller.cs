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
            dynamic result = null;
            var ctrl2 = new Menu_Controller(_repositoryWrapper);
            try
            {
                dynamic Post_Menu_Permission = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermission();

                if (Post_Menu_Permission == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Menu_Permission } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Menu_Permission } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Save_Menu_Permission", Name = "Save_Menu_Permission")]
        public dynamic Save_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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

                result = new { Status = 1, Message = "Save Successfully",data = new { }  };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            
            return result;
        }

        [HttpPost("Update_Menu_Permission", Name = "Update_Menu_Permission")]
        public dynamic Update_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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
                result = new { Status = 1, Message = "Update Successfully",data = new { }  };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Update Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            
            return result;
        }

        [HttpPost("Delete_Menu_Permission", Name = "Delete_Menu_Permission")]
        public dynamic Delete_Menu_Permission([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int menu_permission_id = dd.menu_permission_id;
                int menu_id = dd.menu_id;
                int permission_id = dd.permission_id;

                
                dynamic main = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermissionById(menu_permission_id);
                tbl_menu_permission mp = main as tbl_menu_permission;

                _repositoryWrapper.Menu_Permission_Repository.Delete(mp);
                result = new { Status = 1, Message = "Delete Successfully",data = new { }  };
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