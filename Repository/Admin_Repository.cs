using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Admin_Repository : RepositoryBase<tbAdmin>, IAdmin_Repository
    { 
        public Admin_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        }

        public dynamic GetAdminbyid(int id)
        {
            var result = (from admin in RepositoryContext.tbAdmin
                            where admin.admin_id.Equals(id)
                            select admin
                        ).FirstOrDefault();
            return result;
        }

        public dynamic GetAdminRolebyid(int id)
        {
            var result = (from admin in RepositoryContext.tbAdmin
                            join Role in RepositoryContext.tbl_role_admin on admin.admin_id equals Role.admin_id
                            where admin.admin_id == id
                            select admin
                        ).FirstOrDefault();
            return result;
        }

        public dynamic GetAdminPermissionbyid(int id)
        {
            var result = (from admin in RepositoryContext.tbAdmin
                            join Permission in RepositoryContext.tbl_permission_admin on admin.admin_id equals Permission.admin_id
                            where admin.admin_id == id
                            select admin
                        ).FirstOrDefault();
            return result;
        }
    }
}