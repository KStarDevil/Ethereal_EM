//using Entities.ExtendedModels;

using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdminLevelRepository :IRepositoryBase<Adminlevel>
    {
        IEnumerable<Adminlevel> GetAllAdminLevel();
        IEnumerable<Adminlevel> GetAdminLevelByID(int adminLevelID);
        IEnumerable<Adminlevelmenu> GetAdminLevelMenuBylID(int adminLevelID);
        Adminlevel FindAdminLevel(int adminLevelID);
        int checkDuplicateAdminLevel(int adminLevelID, string adminLevel);
        dynamic GetAdminMenu(int chk);
      
        void DeleteAdminlevelMenu(int AdminLevelID);
        void AddAdminlevelmenu(List<Adminlevelmenu> newlist);

    }

}
