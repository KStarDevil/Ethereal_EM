using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(AppDb repositoryContext) : base(repositoryContext)
        {
            //this.RepositoryContext = repositoryContext;
        }
        public IEnumerable<Admin> GetAllAdmin()
        {
            return FindAll();
        }
        public Admin FindById(int id)
        {
            return FindByID(id);
            /*
            var obj = RepositoryContext.Admin.Find(id);
            if (objcc
                obj.CopyOldObj();
            }
            return obj;*/
        }
        public IEnumerable<Admin> GetAdminByLoginName(string loginName)
        {
            return FindByCondition(x => x.LoginName == loginName).ToList();
        }

        public int CheckDuplicateAdminName(int adminID, string adminName)
        {
            return FindByCondition(x => x.AdminID != adminID && x.AdminName == adminName).Count();
        }
        public int CheckDuplicateAdminLoginName(int adminID, string loginName)
        {
            return FindByCondition(x => x.AdminID != adminID && x.LoginName == loginName).Count();
        }
        /*   public int CheckDuplicateAdminNRC(int adminID, string nrc) {
              return FindByCondition(x => x.AdminID != adminID &&  x.nrc == nrc).Count();
          } */
        public dynamic GetAdmins(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var mainQuery = (from main in RepositoryContext.Admin
                             join level in RepositoryContext.Adminlevel on main.AdminLevelID equals level.AdminLevelID
                             select new
                             {
                                 main.AdminID,
                                 main.AdminLevelID,
                                 main.AdminName,
                                 main.LoginName,
                                 level.AdminLevel,
                                 main.Email,
                                 main.ImagePath, 
                                 main.access_status
                             });
            return mainQuery.ToDataSourceResult(request);
        }
        public IEnumerable<dynamic> GetAdminLoginValidation(string username)
        {
            return (from usr in RepositoryContext.Admin
                    join ul in RepositoryContext.Adminlevel on usr.AdminLevelID equals ul.AdminLevelID into tmp
                    from c in tmp
                    where usr.LoginName == (string)username
                    select new
                    {
                        usr.Password,
                        usr.Salt,
                        usr.AdminID,
                        usr.AdminName,
                        usr.AdminLevelID,
                        usr.login_fail_count,
                        usr.access_status,
                        usr.Email,
                        usr.ImagePath,
                        usr.LoginName,
                        usr.CompanyID,
                        c.restricted_iplist
                    });
        }

        // filter existing query result.   
        public dynamic FilterByAccessStatus(IEnumerable<Admin> admin, sbyte[] accessStatus)
        {
            return admin.Where(m => accessStatus.Contains(m.access_status));
        }
        public dynamic FilterByAdminID(IEnumerable<dynamic> admin, int adminID)
        {
            return admin.Where(m => m.AdminID == adminID);
        }
        public dynamic FilterByStateID(IEnumerable<dynamic> admin, int stateID)
        {
            return admin.Where(m => m.stateid == stateID);
        }
        public dynamic FilterByAdminName(IEnumerable<dynamic> admin, string adminName)
        {
            return admin.Where(m => m.AdminName.Contails(adminName));
        }
        public dynamic FilterByPhone(IEnumerable<dynamic> admin, string phone)
        {
            return admin.Where(m => m.phone.Contails(phone));
        }
        public dynamic FilterByEmail(IEnumerable<dynamic> admin, string email)
        {
            return admin.Where(m => m.Email.Contails(email));
        }

        public dynamic CheckAuthorizedPerson(string CompanyID, string name)
        {
            var query = (from admin in RepositoryContext.Admin
                         where admin.CompanyID == CompanyID && admin.LoginName == name 
                         select admin.AdminID).FirstOrDefault();
            return query;
        }

        public int FindAdminLevelID(int AdminLevelID)
        {
            int count=(from a in RepositoryContext.Admin where a.AdminLevelID==AdminLevelID select a).Count();
            return count;
        }
    }
}
