using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Menu_Permission_Repository : RepositoryBase<tbl_menu_permission>, IMenu_Permission_Repository
    {
        public Menu_Permission_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        }

        public dynamic GetMenuPermission()
        {
            var result =(from menupermission in RepositoryContext.tbl_menu_permission
                        select menupermission
                        ).FirstOrDefault();
            return result;
        }
    }
}