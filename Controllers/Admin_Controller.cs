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
        [HttpGet("GetAdmin", Name = "GetAdmin")]
        public dynamic GetAdmin([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic mainQuery1 = _repositoryWrapper.Menu_Permission_Repository.GetMenuPermission();
                dynamic mainQuery2 = _repositoryWrapper.Role_Admin_Repository.GetRoleAdmin();
                dynamic mainQuery3 = _repositoryWrapper.Permission_Admin_Repository.GetPermissionAdmin();
                if (mainQuery1 == null)
                {
                    jsondata = new { data = new { mainQuery1 = "No Data" } };
                }
                else
                {
                    jsondata = new { data = new { mainQuery1,mainQuery2,mainQuery3 } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }
    }
}