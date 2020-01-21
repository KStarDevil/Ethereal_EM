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
                dynamic dd = param;
                int id = dd.id;
                dynamic mainQuery = _repositoryWrapper.Role_Repository.GetRolebyid(id);
                if (mainQuery == null)
                {
                    jsondata = new { data = new { mainQuery = "No Data" } };
                }
                else
                {
                    jsondata = new { data = new { mainQuery } };
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