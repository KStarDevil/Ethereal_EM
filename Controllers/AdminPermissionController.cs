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
    public class AdminPermissionController : BaseController
    {
         private IRepositoryWrapper _repositoryWrapper;

        public AdminPermissionController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        
        [HttpGet("RoleController", Name = "RoleController")]
        public dynamic RoleController([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
    
            dynamic dd = param;
            int id = dd.id;
            dynamic mainQuery = _repositoryWrapper.AdminPermission.GetAdminPermission(id);  
            int count = mainQuery.Count;
            dynamic jsondata =  new {data= new{Count =count, mainQuery}};
            return jsondata;
        }
        [HttpGet("SaveAdmin", Name = "SaveAdmin")]
        public dynamic SaveAdmin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            string Save = "";
            try
            {
                dynamic dd = param;
                int id = dd.id;

                string admin_name = dd.admin_name;

                int permission_id = dd.permission_id;
                string permission_name = dd.permission_name;

                int relationship_id = dd.relationship_id;
                
                tb_adminmodel a = new tb_adminmodel();
                tb_permissionmodel p = new tb_permissionmodel();
                tb_relationmodel r = new tb_relationmodel();

                a.admin_id = id;
                a.admin_name =admin_name;

                p.permission_id = permission_id;
                p.permission_name=permission_name;

                r.relation_id = relationship_id;
                r.admin_id = id;
                r.permission_id = permission_id;

                _repositoryWrapper.AdminAdmin.Create(a);
                _repositoryWrapper.AdminPermission.Create(p);
                _repositoryWrapper.AdminRelationship.Create(r);

                Save = "Save Successfully";
            }catch(Exception ex)
            {
                Save = ex.Message;
            }    
            return Save;
        }
        [HttpGet("UpdateAdmin", Name = "UpdateAdmin")]
        public dynamic UpdateAdmin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            string update = "";
            try
            {
                dynamic dd = param;
                int id = dd.id;

                string admin_name = dd.admin_name;

                int permission_id = dd.permission_id;
                string permission_name = dd.permission_name;

                int relationship_id = dd.relationship_id;
                
                dynamic a = _repositoryWrapper.AdminAdmin.GetAdminById(id);
                dynamic p = _repositoryWrapper.AdminPermission.GetPermissionById(id);
                dynamic r = _repositoryWrapper.AdminRelationship.GetRelationshipById(id);

                

                a.admin_id = id;
                a.admin_name =admin_name;

                p.permission_id = permission_id;
                p.permission_name=permission_name;

                r.relation_id = relationship_id;
                r.admin_id = id;
                r.permission_id = permission_id;

                _repositoryWrapper.AdminAdmin.Update(a);
                _repositoryWrapper.AdminPermission.Update(p);
                _repositoryWrapper.AdminRelationship.Update(r);

                update = "Save Successfully";
            }catch(Exception ex)
            {
                update = ex.Message;
            }    
            return update;
        }
    }
}