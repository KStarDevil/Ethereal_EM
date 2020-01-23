using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Role_Admin_Repository : RepositoryBase<tbl_role_admin>, IRole_Admin_Repository
    {
        public Role_Admin_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        }

        public dynamic GetRoleAdmin()
        {
            var result =(from roleadmin in RepositoryContext.tbl_role_admin
                        select roleadmin
                        ).FirstOrDefault();
            return result;
        }
    }
}