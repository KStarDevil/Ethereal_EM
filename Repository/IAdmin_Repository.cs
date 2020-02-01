//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdmin_Repository:IRepositoryBase<tbAdmin>
    {
        dynamic GetAdmin();
        dynamic GetAdminbyid(int id);
        dynamic GetAdminRolebyid(int id);
        dynamic GetAdminPermissionbyid(int id);
    }
}
