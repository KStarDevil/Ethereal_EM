//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdminMenuRepository
    {
        IEnumerable<dynamic> GetAdminMenu(int adminLevelID);
        IEnumerable<dynamic> GetAdminMenuByAdminLevel(int adminLevelID);
        IEnumerable<dynamic> GetAdminTransactionMenuByAdminLevel(int adminLevelID);
        IEnumerable<dynamic> GetAdminTransactionMenu(int adminLevelID);
        dynamic GetMenuName(int adminlevelID);

    }
}
