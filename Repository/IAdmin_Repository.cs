//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdmin_Repository : IRepositoryBase<tbl_admin>
    {
        dynamic GetAdmin();
        dynamic GetAdminbyid(int id);
        dynamic GetAdminRolebyid(int id);
        Admin FindById(int ID);
        IEnumerable<dynamic> GetAdminLoginValidation(string username);
    }
}
