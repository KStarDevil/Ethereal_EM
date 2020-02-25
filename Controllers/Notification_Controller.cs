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
    public class Notification_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Notification_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Notification", Name = "Get_Notification")]
        public dynamic Get_Notification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic Post_Notification = _repositoryWrapper.Notification_Repository.GetNotification();
                if (Post_Notification == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Notification } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Notification } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Save_Notification", Name = "Save_Notification")]
        public dynamic Save_Notification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.notification_id;

                string notification_user_photo = dd.notification_user_photo;
                int admin_id = dd.admin_id;
                string notification_title = dd.notification_title;
                string notification_description = dd.notification_description;
                int notification_status = dd.notification_status;
                DateTime notification_date = dd.notification_date;
                string notification_route = dd.notification_route;
                int post_id = dd.post_id;

                tbl_notification noti = new tbl_notification();

                noti.notification_id = id;
                noti.notification_user_photo = notification_user_photo;
                noti.admin_id = admin_id;
                noti.notification_title = notification_title;
                noti.notification_description = notification_description;
                noti.notification_status = notification_status;
                noti.notification_date = notification_date;
                noti.notification_route = notification_route;
                noti.post_id = post_id;

                _repositoryWrapper.Notification_Repository.Create(noti);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Update_Notification", Name = "Update_Notification")]
        public dynamic Update_Notification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.notification_id;

                string notification_user_photo = dd.notification_user_photo;
                int admin_id = dd.admin_id;
                string notification_title = dd.notification_title;
                string notification_description = dd.notification_description;
                int notification_status = dd.notification_status;
                DateTime notification_date = dd.notification_date;
                string notification_route = dd.notification_route;
                int post_id = dd.post_id;

                dynamic noti = _repositoryWrapper.Notification_Repository.GetPermissionById(id);
                // tbl_notification noti = new tbl_notification();

                noti.notification_id = id;
                noti.notification_user_photo = notification_user_photo;
                noti.admin_id = admin_id;
                noti.notification_title = notification_title;
                noti.notification_description = notification_description;
                noti.notification_status = notification_status;
                noti.notification_date = notification_date;
                noti.notification_route = notification_route;
                noti.post_id = post_id;

                _repositoryWrapper.Notification_Repository.Update(noti);
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Update Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        [HttpPost("Delete_Notification", Name = "Delete_Notification")]
        public dynamic Delete_Notification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.notification_id;
                dynamic main = _repositoryWrapper.Notification_Repository.GetPermissionById(id);
                tbl_notification noti = main as tbl_notification;

                _repositoryWrapper.Notification_Repository.Delete(noti);
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
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