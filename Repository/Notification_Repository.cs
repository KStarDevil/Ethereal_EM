using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Notification_Repository : RepositoryBase<tbl_notification>, INotification_Repository
    {
        public Notification_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetNotification()
        {
            var result = (from notification in RepositoryContext.tbl_notifications
                          select notification
                        ).ToList();
            return result;
        }
        public dynamic GetPermissionById(int id)
        {
            var result = (from Notification in RepositoryContext.tbl_notifications
                          where Notification.notification_id == id
                          select Notification
            ).FirstOrDefault();

            return result;
        }
        public dynamic Get_Notification_By_CategoryID_UserID(int[] id, int user_id)
        {

            List<tbl_notification> mini_result = new List<tbl_notification>();

            dynamic result = null;
            foreach (var item in id)
            {
                var Noti_Cat = (from Notification in RepositoryContext.tbl_notifications
                                where Notification.notification_user.Contains(user_id.ToString())
                                select Notification
                                   ).ToList();
                foreach (var item1 in Noti_Cat)
                {
                    mini_result.Add(item1);
                }
            }
            string noti_id = string.Join(",", mini_result.Distinct().Select(x => x.notification_id));

            tbl_user_notification select = (from user_noti in RepositoryContext.tbl_user_notification
                                            where user_noti.user_id.Equals(user_id)
                                            select user_noti
                        ).FirstOrDefault();
            int index = noti_id.IndexOf(select.notification_id);
            string[] before_string = noti_id.Split(",");

            List<string> after_sting = new List<string>();

            foreach (var item in before_string)
            {
                if (select.notification_id.Contains(item))
                {
                    after_sting.Add(item);
                }

            }
            string after = String.Join(", ", after_sting.ToArray());
            var cat = (from mini in mini_result
                       select new
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
                           notification_is_active = after_sting.Contains(mini.notification_id.ToString()) ? 1 : 0,
                       }
            ).Distinct().AsQueryable();
            return result = cat;
        }
    }
}