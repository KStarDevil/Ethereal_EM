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
        [HttpGet("GetNotification", Name = "GetNotification")]
        public dynamic GetNotification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostNotification = _repositoryWrapper.Notification_Repository.GetNotification();
                if (PostNotification == null)
                {
                    jsondata = new {  status = 0, Message = "No Data", data = new { PostNotification } };
                }
                else
                {
                    jsondata = new { status = 1, Message = "Success", data = new { PostNotification } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }

        [HttpPost("SaveNotification", Name = "SaveNotification")]
        public dynamic SaveNotification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save =null;
            try
            {
                dynamic dd = param;
                int id = dd.notification_id;

                string notification_user_photo = dd.notification_user_photo;
                int admin_id =dd.admin_id;
                string notification_title =dd.notification_title;
                string notification_description= dd.notification_description;
                int notification_status =dd.notification_status;
                DateTime notification_date =dd.notification_date;
                string notification_route=dd.notification_route;
                int post_id =dd.post_id;

                tbl_notification noti = new tbl_notification();

                noti.notification_id = id;
                noti.notification_user_photo=notification_user_photo;
                noti.admin_id = admin_id;
                noti.notification_title=notification_title;
                noti.notification_description=notification_description;
                noti.notification_status=notification_status;
                noti.notification_date=notification_date;
                noti.notification_route = notification_route;
                noti.post_id = post_id;

                _repositoryWrapper.Notification_Repository.Create(noti);
            }catch(Exception ex)
            {
                save = new { status = 0, Message =ex.Message};
            }
            save = "Save Successfully";
            return save;
        }

        [HttpPost("UpdateNotification", Name = "UpdateNotification")]
        public dynamic UpdateNotification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic update =null;
            try
            {
                dynamic dd = param;
                int id = dd.notification_id;

                string notification_user_photo = dd.notification_user_photo;
                int admin_id =dd.admin_id;
                string notification_title =dd.notification_title;
                string notification_description= dd.notification_description;
                int notification_status =dd.notification_status;
                DateTime notification_date =dd.notification_date;
                string notification_route=dd.notification_route;
                int post_id =dd.post_id;

                dynamic noti =_repositoryWrapper.Notification_Repository.GetPermissionById(id);
                // tbl_notification noti = new tbl_notification();

                noti.notification_id = id;
                noti.notification_user_photo=notification_user_photo;
                noti.admin_id = admin_id;
                noti.notification_title=notification_title;
                noti.notification_description=notification_description;
                noti.notification_status=notification_status;
                noti.notification_date=notification_date;
                noti.notification_route = notification_route;
                noti.post_id = post_id;

                _repositoryWrapper.Notification_Repository.Update(noti);
            }catch(Exception ex)
            {
                update = new { status = 0, Message =ex.Message};
            }
            update = "Update Successfully";
            return update;
        }
        [HttpPost("DeleteNotification", Name = "DeleteNotification")]
        public dynamic DeleteNotification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                
                dynamic result = null;
                try
                {
                    dynamic dd = param;
                    int id = dd.notification_id;

                    string notification_user_photo = dd.notification_user_photo;
                    int admin_id =dd.admin_id;
                    string notification_title =dd.notification_title;
                    string notification_description= dd.notification_description;
                    int notification_status =dd.notification_status;
                    DateTime notification_date =dd.notification_date;
                    string notification_route=dd.notification_route;
                    int post_id =dd.post_id;

                  
                    dynamic main = _repositoryWrapper.Notification_Repository.GetPermissionById(id);
                    tbl_notification noti = main as tbl_notification;
                    
                    _repositoryWrapper.Notification_Repository.Delete(noti);
                    result = "Delete Successfully";
                }
                catch (Exception ex)
                {
                    result = new { data = new { msg = ex.Message } };
                }
                return result;
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }
    }
}