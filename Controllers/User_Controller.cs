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

            dynamic result = null;
            try
            {
                dynamic Post_User = _repositoryWrapper.User_Repository.Get_all_user();
                if (Post_User != null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_User } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_User } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("SaveUser", Name = "SaveUser")]
        public dynamic SaveUser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.user_id;

                string user_name = dd.user_name;
                string user_phone = dd.user_phone;
                string user_location = dd.user_location;               
                DateTime user_registered_date = dd.user_registered_date;
                string user_email = dd.user_email;

                tbl_user u = new tbl_user();

                u.user_id =id;
                u.user_name = user_name;
                u.user_phone = user_phone;
                u.user_location = user_location ;
                u.user_registered_date = user_registered_date;
                u.user_email = user_email;


              
                _repositoryWrapper.User_Repository.Create(u);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }

        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public dynamic UpdateUser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.user_id;

                string user_name = dd.user_name;
                string user_phone = dd.user_phone;
                string user_location = dd.user_location;               
                DateTime user_registered_date = dd.user_registered_date;
                string user_email = dd.user_email;

                dynamic main = _repositoryWrapper.User_Repository.Get_user_by_id(id);
                tbl_user u = main as tbl_user;

                u.user_id =id;
                u.user_name = user_name;
                u.user_phone = user_phone;
                u.user_location = user_location ;
                u.user_registered_date = user_registered_date;
                u.user_email = user_email;


              
                _repositoryWrapper.User_Repository.Update(u);
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }

        [HttpPost("DeleteUser", Name = "DeleteUser")]
        public dynamic DeleteUser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.user_id;

                string user_name = dd.user_name;
                string user_phone = dd.user_phone;
                string user_location = dd.user_location;               
                DateTime user_registered_date = dd.user_registered_date;
                string user_email = dd.user_email;

                dynamic main = _repositoryWrapper.User_Repository.Get_user_by_id(id);
                tbl_user  u = main as tbl_user;
                
                
        
                _repositoryWrapper.User_Repository.Delete(u);
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }

    }
}