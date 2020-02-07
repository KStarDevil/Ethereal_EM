using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Menu_Repository : RepositoryBase<tbl_menu>, IMenu_Repository
    {
        public Menu_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public List<tbl_menu> GetMenu()
        {
            var result1 = (from menu in RepositoryContext.tbl_menu
                           select menu
                        ).ToList();
            List<tbl_menu> result = result1 as List<tbl_menu>;
            return result;
        }
        public List<tbl_menu> Get_Menu_By_Amdin_ID(int ID)
        {
            var result1 = (from admin in RepositoryContext.tbl_admin
                           join permission_role in RepositoryContext.tbl_permission_role on admin.admin_role_id equals permission_role.role_id
                           join menu_permission in RepositoryContext.tbl_menu_permission on permission_role.permission_id equals menu_permission.permission_id
                           join menu in RepositoryContext.tbl_menu on menu_permission.menu_id equals menu.menu_id
                           where admin.admin_id == ID
                           select menu
                        ).ToList();
            List<tbl_menu> result = result1 as List<tbl_menu>;
            return result;
        }
    }
}