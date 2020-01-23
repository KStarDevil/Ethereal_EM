using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Role_Repository : RepositoryBase<tbl_role>, IRole_Repository
    {
        public Role_Repository(AppDb reposityContext)

        :base(reposityContext)
        {
        }

        public dynamic GetAllRole()
        {
            var result = (from role in RepositoryContext.tbl_role
                            select role
                            ).ToList();
            return result;
        }

        public dynamic GetRolebyid(int id)
        {
            var result = (from role in RepositoryContext.tbl_role
                            where role.role_id == id 
                            select role
                            ).FirstOrDefault();
            return result;
        }
    }
}