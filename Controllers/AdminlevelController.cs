using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Ethereal_EM.Repository;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class AdminlevelController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public AdminlevelController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("GetAdminLevel/{AdminLevelID}", Name = "GetAdminLevel")]
        [Authorize]
        public dynamic GetAdminLevel(int AdminLevelID)
        {
            dynamic objresult = null;
            if (AdminLevelID == 0)
            {
                objresult = _repositoryWrapper.AdminLevel.GetAllAdminLevel();
            }
            else
            {
                objresult = _repositoryWrapper.AdminLevel.GetAdminLevelByID(AdminLevelID);
            }
            dynamic objresponse = new { data = objresult };
            return objresponse;
        }

        [HttpGet("GetAdminLevelMenu/{AdminLevelID}", Name = "GetAdminLevelMenu")]
        [Authorize]
        public dynamic GetAdminLevelMenu(int AdminLevelID)
        {
            dynamic objresult = null;
            if (AdminLevelID > 0)
            {

                var adminmenu = (_repositoryWrapper.AdminLevel.GetAdminMenu(1));
                var adminlevel = (_repositoryWrapper.AdminLevel.GetAdminLevelMenuBylID(AdminLevelID)).ToList();
                List<dynamic> dd = new List<dynamic>();
                foreach (var q in adminmenu)
                {

                    var found = adminlevel.Find(adlv => adlv.AdminMenuID == q.ID);
                    var ischecked = 0;
                    if (found != null)
                    {
                        ischecked = 1;
                    }
                    else
                    {
                        ischecked = 0;
                    }
                    var newobj = new { ID = q.ID, Name = q.Name, ParentID = q.ParentID, Checked = ischecked };
                    dd.Add(newobj);
                }
                dynamic objresponsewithlvl = new { data = dd };
                return objresponsewithlvl;
            }
            else
            {
                objresult = (_repositoryWrapper.AdminLevel.GetAdminMenu(0));
            }
            dynamic objresponse = new { data = objresult };
            return objresponse;
        }

        [HttpPost("checkDuplicate", Name = "AdminLevelcheckDuplicate")]
        [Authorize]
        public dynamic checkDuplicate([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int AdminLevelID = obj.AdminLevelID != null ? obj.AdminLevelID : 0;
            string AdminLevel_string = obj.AdminLevel;
            var adminlevellist = _repositoryWrapper.AdminLevel.checkDuplicateAdminLevel(AdminLevelID, AdminLevel_string);

            if (adminlevellist > 0)
            {
                objresult = new { AdminLevel = 1 };
            }
            else
            {
                objresult = new { AdminLevel = 0 };
            }

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }

        [HttpPost("AddAdminLevel", Name = "AddAdminLevel")]
        [Authorize]
        public dynamic AddAdminLevel([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;

            int AdminLevelID = obj.AdminLevelID != null ? obj.AdminLevelID : 0;
            string AdminLevel = obj.AdminLevel;

            var objAdminlevel = _repositoryWrapper.AdminLevel.FindAdminLevel(AdminLevelID);
            if (objAdminlevel != null)
            {
                string Adminlevel = obj.AdminLevel;
                string restricted_iplist = obj.restricted_iplist;
                string Remark = obj.Remark;
                string Description = obj.Description;
                objAdminlevel.AdminLevel = Adminlevel;
                objAdminlevel.restricted_iplist = restricted_iplist;
                objAdminlevel.Remark = Remark;
                objAdminlevel.Description = Description;
                objAdminlevel.modified_date = System.DateTime.Now;
                _repositoryWrapper.AdminLevel.Update(objAdminlevel);
                _repositoryWrapper.AdminLevel.Save();
                _repositoryWrapper.EventLog.Update(objAdminlevel);
            }
            else
            {
                var newobj = new Adminlevel();
                newobj.AdminLevel = obj.AdminLevel;
                newobj.restricted_iplist = (obj.restricted_iplist == null) ? "" : obj.restricted_iplist;
                newobj.Description = (obj.Description == null) ? "" : obj.Description;
                newobj.Remark = (obj.Remark == null) ? "" : obj.Remark;
                newobj.created_date = System.DateTime.Now;
                newobj.modified_date = System.DateTime.Now;

                _repositoryWrapper.AdminLevel.Create(newobj);
                _repositoryWrapper.AdminLevel.Save();

                _repositoryWrapper.EventLog.Insert(newobj);

                AdminLevelID = newobj.AdminLevelID;
            }

            dynamic objresponse = new { data = AdminLevelID };
            return objresponse;
        }

        [HttpPost("AddAdminLevelMenu/{AdminLevelID}", Name = "AddAdminLevelMenu")]
        [Authorize]
        public dynamic AddAdminLevelMenu(int AdminLevelID, [FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            bool retBool = false;
            dynamic obj = param;
            var objAdminMenuList = (string)obj.adminMenuList;
            //var objAdminMenuList = (string)HttpContext.Request.Form["objAdminMenuList"];
            string[] arr_AdminMenu = null;
            if (objAdminMenuList.Length > 0)
            {
                arr_AdminMenu = objAdminMenuList.Split(',');
                if (arr_AdminMenu.Length > 0)
                {
                    _repositoryWrapper.AdminLevel.DeleteAdminlevelMenu(AdminLevelID);

                    List<Adminlevelmenu> newlist = new List<Adminlevelmenu>();
                    for (int i = 0; i <= arr_AdminMenu.Length - 1; i++)
                    {
                        var newobj = new Adminlevelmenu();
                        newobj.AdminLevelID = AdminLevelID;
                        newobj.AdminMenuID = int.Parse(arr_AdminMenu[i]);
                        newlist.Add(newobj);
                    }

                    if (newlist.Count > 0)
                    {
                        _repositoryWrapper.AdminLevel.AddAdminlevelmenu(newlist);
                        retBool = true;
                    }
                }
            }
            dynamic objresponse = new { data = retBool };
            return objresponse;
        }

        [HttpDelete("DeleteAdminLevel/{AdminLevelID}", Name = "DeleteAdminLevel")]
        [Authorize]
        public dynamic DeleteAdminLevel(int AdminLevelID)
        {
            bool retBool = false;
            int userresult = _repositoryWrapper.Admin.FindAdminLevelID(AdminLevelID);
            if (userresult >0)
            {
                retBool = false;
            }
            else
            {
                var objAdminlevel = _repositoryWrapper.AdminLevel.FindAdminLevel(AdminLevelID);
                if (objAdminlevel != null)
                {
                    _repositoryWrapper.AdminLevel.Delete(objAdminlevel);
                    retBool = true;
                    _repositoryWrapper.EventLog.Delete(objAdminlevel);
                }
            }
            dynamic objresponse = new { data = retBool };
            return objresponse;
        }
    }
}