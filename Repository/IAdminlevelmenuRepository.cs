//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdminlevelmenuRepository
    {
        Adminlevelmenu GetAdminlevelmenuByAdminLevelIDAdminMenuID(int AdminLevelID, int AdminMenuID);
    }
}
