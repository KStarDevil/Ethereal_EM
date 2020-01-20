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
    public class TestingForBunny : BaseController
    {
         private IRepositoryWrapper _repositoryWrapper;

        public TestingForBunny(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpGet("RainController", Name = "RainController")]
        public dynamic RainController([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            var ctrl = new AdminPermissionController(_repositoryWrapper);
            ctrl.ControllerContext = ControllerContext;
            dynamic data1 = ctrl.RoleController(param);
            dynamic dd = param;
            int id = dd.id;
            dynamic mainQuery = _repositoryWrapper.Account.GetAccount(id);  
            int count = mainQuery.Count;
            dynamic jsondata =  new {data= new{Count =count, mainQuery,data1}};
            return jsondata;
        }

        
    }
}