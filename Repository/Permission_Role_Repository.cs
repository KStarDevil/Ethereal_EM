using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Permission_Role_Repository : RepositoryBase<tbl_permission_role>, IPermission_Role_Repository
    {
        public Permission_Role_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        }

        public dynamic Get_Permission_By_Role(int Id)
        {
              var result = (from permission_role in RepositoryContext.tbl_permission_role
                            where permission_role.role_id==Id
                            select permission_role
                            );
            return result;
        }
    }
}