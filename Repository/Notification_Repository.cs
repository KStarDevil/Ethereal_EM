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

        :base(reposityContext)
        {
        }

        public dynamic GetNotification()
        {
            var result =(from notification in RepositoryContext.tbl_notifications
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
    }
}