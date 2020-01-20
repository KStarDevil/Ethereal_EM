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
    public class hw_tb1_userController : BaseController
    {
         private IRepositoryWrapper _repositoryWrapper;

        public hw_tb1_userController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("GetUser", Name ="GetUser")]
        public dynamic GetUser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            var ctrl1 = new hw_tb1_accountController(_repositoryWrapper);
            ctrl1.ControllerContext = ControllerContext;
            

            var ctrl2 = new hw_tb1_registerController(_repositoryWrapper);
            ctrl1.ControllerContext = ControllerContext;
            

            dynamic dd = param;
            int id = dd.id;

            dynamic mainQuery = _repositoryWrapper.hw_tb1_userRepo.GetUser(id); 
            
            dynamic data1 = ctrl1.GetAccount(mainQuery);
            dynamic data2 = ctrl2.GetRegister(data1);

            // int count = mainQuery.Count;
            dynamic jsondata =  new {data= new{mainQuery,data1,data2}};
            return jsondata;
        }
    }
}