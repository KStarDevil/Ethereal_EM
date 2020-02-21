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
    public class User_Notification_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public User_Notification_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_User_Notification", Name = "Get_User_Notification")]
        public dynamic Get_User_Notification([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.user_id;
                int[] category_id = new int[] { };
                int currentPage = dd.currentPage;
                int rowsPerPage = dd.rowsPerPage;
                if (dd.category_id != null)
                {
                    category_id = dd.category_id.ToObject<int[]>();

                }
                else
                {
                    category_id = new int[0];
                }
                dynamic Post_Notification = _repositoryWrapper.Notification_Repository.Get_Notification_By_CategoryID_UserID(category_id, id);
                IEnumerable<dynamic> tamplist = PaginatedList<dynamic>.Create(Post_Notification, currentPage, rowsPerPage);
                var PostData = tamplist.Select(mini =>
                                new
                                {
                                    notification_id = mini.notification_id,
                                    notification_user_photo = mini.notification_user_photo,
                                    admin_id = mini.admin_id,
                                    notification_title = mini.notification_title,
                                    notification_description = mini.notification_description,
                                    notification_status = mini.notification_status,
                                    notification_date = mini.notification_date,
                                    notification_route = mini.notification_route,
                                    post_id = mini.post_id,
                                    notification_category = mini.notification_category,
                                    notification_user = mini.notification_user,
                                    notification_is_active = mini.notification_is_active,
                                }).ToList();
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
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }
    }
}