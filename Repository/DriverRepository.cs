using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public int CheckDuplicateCard(int DriverID, string cardno)
        {
            return FindByCondition(x => x.driverID != DriverID && x.cardNo == cardno).Count();
        }

        public int CheckDuplicateLicense(int DriverID, string License)
        {
            return FindByCondition(x => x.driverID != DriverID && x.license == License).Count();
        }

        public int CheckDuplicateNRC(int DriverID, int nrc)
        {
            return FindByCondition(x => x.driverID != DriverID && x.nrcNo == nrc).Count();
        }

        public int CheckDuplicatePhone(int DriverID, string Phone)
        {
            return FindByCondition(x => x.driverID != DriverID && x.phone == Phone).Count();
        }

        public dynamic GetAllDriverList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var MainQuery = (from main in RepositoryContext.Driver
                             join ge in RepositoryContext.General on main.township equals ge.id
                             where main.inactive == true
                             select new
                             {
                                 DriverID = main.driverID,
                                 Name = main.name,
                                 Address = main.address,
                                 Phone = main.phone,
                                 CardNo = main.cardNo,
                                 License = main.license,
                                 Township = ge.name,
                                 Photo = main.photo
                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetAllMobileDriverList()
        {
            dynamic objResponse = null;

            try
            {
                var MainQuery = (from main in RepositoryContext.Driver
                                 join ge in RepositoryContext.General on main.township equals ge.id
                                 where main.inactive == true
                                 select new
                                 {
                                     DriverID = main.driverID,
                                     Name = main.name,
                                     Address = main.address,
                                     Phone = main.phone,
                                     CardNo = main.cardNo,
                                     License = main.license,
                                     Township = ge.name,
                                     State = RepositoryContext.General.Where(s => s.id == main.state).Select(s => s.name).FirstOrDefault(),
                                     NrcDivisionCode = RepositoryContext.General.Where(s => s.id == main.nrcDivisionCode).Select(s => s.name).FirstOrDefault(),
                                     TownshipCode = RepositoryContext.General.Where(s => s.id == main.nrcTownshipCode).Select(s => s.name).FirstOrDefault(),
                                     NrcCitizenCode = RepositoryContext.General.Where(s => s.id == main.nrcCitizenCode).Select(s => s.name).FirstOrDefault(),
                                     NrcNo = main.nrcNo,

                                 }).ToList();
                objResponse = MainQuery;
            }
            catch (Exception ex)
            {
                objResponse = ex.Message;
            }
            return objResponse;
        }

        public dynamic GetDriverCombo()
        {
            var query = (from main in RepositoryContext.Driver
                         where main.inactive == true
                         select new
                         {
                             main.driverID,
                             main.name,
                         });
            return query;
        }

        public dynamic GetDriverData(int DriverID)
        {
            var query = (from main in RepositoryContext.Driver
                         where main.driverID == DriverID
                         select new
                         {
                             DriverID = main.driverID,
                             main.name,
                             nrc = main.nrcNo,
                             License = main.license,
                             Address = main.address,
                             Phone = main.phone,
                             cardno = main.cardNo,
                             TownshipID = main.township,
                             StateID = main.state,
                             divisioncode = main.nrcDivisionCode,
                             townshipcode = main.nrcTownshipCode,
                             citizencode = main.nrcCitizenCode,
                             Photo = main.photo
                         });
            return query;
        }

        public dynamic GetDriverName(string Name)
        {
            var query = (from main in RepositoryContext.Driver
                         where main.inactive == true && main.cardNo == Name
                         select new
                         {
                             main.name,
                             main.driverID
                         }).FirstOrDefault();
            return query;
        }
    }
}