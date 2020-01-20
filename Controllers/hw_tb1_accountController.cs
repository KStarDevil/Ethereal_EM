using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.ComponentModel.DataAnnotations;


namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class hw_tb1_accountController : BaseController
    {
         private IRepositoryWrapper _repositoryWrapper;

        public hw_tb1_accountController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("GetAccount", Name ="GetAccount")]
        public dynamic GetAccount([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            // var ctrl = new AdminPermissionController(_repositoryWrapper);
            // ctrl.ControllerContext = ControllerContext;
            // dynamic data1 = ctrl.RoleController(param);
            dynamic dd = param;
            string name = dd.name;
            dynamic mainQuery = _repositoryWrapper.hw_tb1_accountRepo.Getaccount(name);  
            
            dynamic jsondata =  new {data= new{mainQuery}};
            return jsondata;
        }
    }
}