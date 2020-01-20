using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class BowserRepository : RepositoryBase<Bowser>, IBowserRepository
    {
        public BowserRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public int CheckDuplicateCarNo(int BowserID, string carno)
        {
            return FindByCondition(x => x.bowserID != BowserID && x.carNo == carno).Count();
        }

        public int CheckDuplicatePhone(int BowserID, string Phone)
        {
            return FindByCondition(x => x.bowserID != BowserID && x.phone == Phone).Count();
        }

        public dynamic GetAllBowserList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param); 
            var MainQuery = (from main in RepositoryContext.Bowser
                             where main.inactive == true
                             select new
                             {
                                 BowserID = main.bowserID,
                                 BowserName = main.bowserName,
                                 Address = main.address,
                                 Phone = main.phone,
                                 CarNo = main.carNo,
                                 OwnerName = main.ownerName,
                                 Status = main.status,
                                 userType = main.user_type

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetBowserData(int BowserID)
        {
            var query = (from main in RepositoryContext.Bowser
                         where main.bowserID == BowserID
                         select new
                         {
                             BowserID = main.bowserID,
                             bowsername = main.bowserName,
                             carno = main.carNo,
                             ownername = main.ownerName,
                             address = main.address,
                             phone =main.phone,
                             item = (from c in RepositoryContext.Compartment
                                     where c.bowserID == BowserID && c.inactive == true
                                     select new
                                     {
                                         ID = c.compartmentID,
                                         Name = c.name,
                                         Size = c.capacity,
                                         Calibration = c.calibration
                                     }).ToList(),
                             main.status
                         });
            return query;
        }

        public dynamic GetAllBowserListMoblie()
        {
            dynamic objResponse = null;

            try
            {

                var MainQuery = (from main in RepositoryContext.Bowser
                                 where main.inactive == true
                                 select new
                                 {
                                     BowserID = main.bowserID,
                                     BowserName = main.bowserName,
                                     Address = main.address,
                                     Phone = main.phone,
                                     CarNo = main.carNo,
                                     OwnerName = main.ownerName

                                 }).ToList();
                objResponse = MainQuery;
            }
            catch (Exception ex)
            {
                objResponse = ex.Message;
            }
            return objResponse;
        }

        public dynamic GetBowserCombo()
        {
            var query = (from main in RepositoryContext.Bowser
                         where main.inactive == true
                         select new
                         {
                             main.bowserID,
                             main.carNo,
                         });
            return query;
        }

        public dynamic GetBowserComboData(int DriverID)
        {
            var query = (from demand in RepositoryContext.DemandOrder 
                join main in RepositoryContext.Bowser on demand.bowserID equals main.bowserID
                         where main.inactive == true
                         select new
                         {
                             main.bowserID,
                             main.carNo,
                         });
            return query;
        }
    }
}