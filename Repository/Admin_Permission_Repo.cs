using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Admin_Permission_Repo : RepositoryBase<tb_permissionmodel>, IAdmin_Permission_Repo
    {   
        public Admin_Permission_Repo(AppDb repositoryContext)
        
            : base(repositoryContext)
        {
        }
        public dynamic GetPermissionById(int id)
        {
            var result = (from Permission in RepositoryContext.tb_permissionmodel
                       where Permission.permission_id == id
                       select Permission
            ).FirstOrDefault();

            return result;
        }
        public dynamic GetAdminPermission(int id)
        {
            var adminpermission =   (from Relation in RepositoryContext.tb_relationmodel
                                    join Admin in RepositoryContext.tb_adminmodel on Relation.admin_id equals Admin.admin_id
                                    join Permission in RepositoryContext.tb_permissionmodel on Relation.permission_id equals Permission.permission_id
                                    where Admin.admin_id == id
                                    select new 
                                    {
                                        name = Admin.admin_name,
                                        role = Permission.permission_name
                                    }).ToList();
            return adminpermission;
            
        }
    }
}