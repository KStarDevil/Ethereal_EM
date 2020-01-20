//using Entities.ExtendedModels;
using Ethereal_EM;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdminRepository :IRepositoryBase <Admin>
    {
        IEnumerable<Admin> GetAllAdmin();
        IEnumerable<Admin> GetAdminByLoginName(string loginName);
       
        //void AddAdmin(Admin admin);
       // void UpdateAdmin(Admin admin);
        Admin FindById(int ID);
        dynamic GetAdmins(dynamic param);
        int FindAdminLevelID(int AdminLevelID);
       
        IEnumerable<dynamic> GetAdminLoginValidation(string username);
        dynamic FilterByAccessStatus(IEnumerable<Admin> admin, sbyte[] accessStatus);
        dynamic FilterByAdminID(IEnumerable<dynamic> admin, int adminID);
        dynamic FilterByStateID(IEnumerable<dynamic> admin, int stateID);
        dynamic FilterByAdminName(IEnumerable<dynamic> admin, string adminName);
        dynamic FilterByPhone(IEnumerable<dynamic> admin, string phone);
        dynamic FilterByEmail(IEnumerable<dynamic> admin, string email);
        dynamic CheckAuthorizedPerson(string CompanyID, string name);
        int CheckDuplicateAdminName(int adminID, string adminName);
        int CheckDuplicateAdminLoginName(int adminID, string loginName);
        //int CheckDuplicateAdminNRC(int adminID, string nrc);

    }
       
}
