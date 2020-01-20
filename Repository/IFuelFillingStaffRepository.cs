using System;
using System.Collections.Generic;
using Ethereal_EM;

namespace Ethereal_EM.Repository
{
    public interface IFuelFillingStaffRepository : IRepositoryBase<FuelFillingStaff>
    {
        int CheckDuplicateCode(int staffID, string code);
        int CheckDuplicateUserName(int staffID, string Username);
        int CheckDuplicateEmail(int staffID, string Email);
        int CheckDuplicatePhone(int staffID, string Phone);
        dynamic GetAllStaffList(dynamic param);
        dynamic GetStaffData(int StaffID);
    }
}