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
    public class User_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public User_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpGet("Get_All_User", Name = "Get_All_User")]
        public dynamic Get_All_User([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic jsondata = null;
            try
            {
                dynamic PostData = _repositoryWrapper.User_Repository.Get_all_user();
                if (PostData != null)
                {
                    jsondata = new { status = 1, Message = "Success", data = new { PostData } };
                }
                else
                {
                    jsondata = new { status = 0, Message = "No Data", data = new { PostData } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { status = 0, Message = ex.Message };
            }
            return jsondata;
        }



    }
}