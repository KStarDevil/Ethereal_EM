using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Permission_Repository : RepositoryBase<tbl_permission>, IPermission_Repository
    {
        public Permission_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        } 
        public dynamic GetPermissionbyid(int id){
            var result = (from permission in RepositoryContext.tbl_permission
                            where permission.permission_id==id
                            select permission
                            ).FirstOrDefault();
            return result;
        }

        

        public dynamic GetAllPermission()
        {
            var result = (from permission in RepositoryContext.tbl_permission
                            select permission
                            ).ToList();
            return result;
        }
    }
}