using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class FuelFillingStaffRepository : RepositoryBase<FuelFillingStaff>, IFuelFillingStaffRepository
    {
        public FuelFillingStaffRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public int CheckDuplicateCode(int staffID, string code)
        {
            return FindByCondition(x => x.staffID != staffID && x.code == code).Count();
        }

        public int CheckDuplicateEmail(int staffID, string Email)
        {
            return FindByCondition(x => x.staffID != staffID && x.email == Email).Count();
        }

        public int CheckDuplicatePhone(int staffID, string Phone)
        {
             return FindByCondition(x => x.staffID != staffID && x.phone == Phone).Count();
        }

        public int CheckDuplicateUserName(int staffID, string Username)
        {
             return FindByCondition(x => x.staffID != staffID && x.username == Username).Count();
        }

        public dynamic GetAllStaffList(dynamic param)
        {
           DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var MainQuery = (from main in RepositoryContext.FuelFillingStaff
                             where main.inactive == true
                             select new
                             {
                                 StaffID = main.staffID,
                                 StaffName = main.staffname,
                                 Address = main.address,
                                 Phone = main.phone,
                                 Code = main.code,
                                 Email = main.email,
                                 main.access_status

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetStaffData(int StaffID)
        {
           var query = (from staff in RepositoryContext.FuelFillingStaff
                         where staff.staffID == StaffID
                         select new
                         {
                             name = staff.staffname,
                             code = staff.code,
                             staff.username,
                             Address = staff.address,
                             Phone = staff.phone,
                             TownshipID = staff.township,
                             StateID = staff.state,
                             Email = staff.email,
                             StaffID = staff.staffID,
                             Password=staff.password,
                             ConfirmPassword=staff.password
                         });
            return query;
        }
    }
}