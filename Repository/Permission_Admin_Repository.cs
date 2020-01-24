using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Permission_Admin_Repository : RepositoryBase<tbl_permission_admin>, IPermission_Admin_Repository
    {
        public Permission_Admin_Repository(AppDb reposityContext)
            : base(reposityContext)
        {
        }

        public dynamic GetPermissionAdmin()
        {
            var result = (from permissionadmin in RepositoryContext.tbl_permission_admin
                          select permissionadmin
                        ).ToList();
            return result;
        }

        public dynamic GetPermissionAdminByID(int id)
        {
            var result = (from permissionadmin in RepositoryContext.tbl_permission_admin
                          where permissionadmin.permission_admin_id == id
                          select permissionadmin
                        ).FirstOrDefault();
            return result;
        }
    }

}