using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class AdminLevelRepository: RepositoryBase<Adminlevel>, IAdminLevelRepository
    {
        public AdminLevelRepository(AppDb repositoryContext):base(repositoryContext)
        {
           
        }
       public IEnumerable<Adminlevel> GetAllAdminLevel() {
            return FindAll();
        }

        public Adminlevel FindAdminLevel(int adminLevelID) {
             return FindByID(adminLevelID);
             /*var obj= RepositoryContext.Adminlevel.Find(adminLevelID);
            if(obj!=null)
            {
                obj.CopyOldObj();
            }
            return obj;*/
        }
        public IEnumerable<Adminlevel> GetAdminLevelByID(int adminLevelID) {
            return  FindByCondition(x => x.AdminLevelID == adminLevelID);
        }

        public IEnumerable<Adminlevelmenu> GetAdminLevelMenuBylID(int adminLevelID) {
           return   (from adl in RepositoryContext.Adminlevelmenu
                     where adl.AdminLevelID == adminLevelID
                     select adl);             
        }
        public dynamic GetAdminMenu(int chk) {
            return (from main in RepositoryContext.Adminmenu
                    orderby main.SrNo
                    select main).ToList()
                    .Select(q => new
                    {
                        ID = q.AdminMenuID,
                        Name = q.AdminMenuName,
                        ParentID = q.ParentID,
                        Checked = chk
                    });
        }

        public int checkDuplicateAdminLevel(int adminLevelID, string adminLevel) 
        {
            return FindByCondition(x => x.AdminLevelID != adminLevelID && x.AdminLevel == adminLevel).Count();
        }

       
      

        public void DeleteAdminlevelMenu(int AdminLevelID)
        {
            var Adminlevelmenu = (from alm in RepositoryContext.Adminlevelmenu
                                  where alm.AdminLevelID == AdminLevelID
                                  select alm).ToList();
            RepositoryContext.Adminlevelmenu.RemoveRange(Adminlevelmenu);
            Save();
        }

        public void AddAdminlevelmenu(List<Adminlevelmenu> newlist)
        {
            RepositoryContext.Adminlevelmenu.AddRange(newlist);
            Save();
        }
      
    }
}
