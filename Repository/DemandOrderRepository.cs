using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class DemandOrderRepository : RepositoryBase<DemandOrder>, IDemandOrderRepository
    {
        public DemandOrderRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetAllDemandOrderList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var MainQuery = (from main in RepositoryContext.DemandOrder
                             join driver in RepositoryContext.Driver on main.driverID equals driver.driverID
                             join bowser in RepositoryContext.Bowser on main.bowserID equals bowser.bowserID
                             join customer in RepositoryContext.Customer on main.customerID equals customer.customerID
                             where main.inactive == true
                             select new
                             {
                                 DemandOrderID = main.demandorderID,
                                 OrderDate = main.deliveryorderDate,
                                 DriverName = driver.name,
                                 CarNo = bowser.carNo,
                                 Customer = customer.customername,
                                 DeliveryDate = main.deliveryDate,

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetDemandOrderData(string DemandOrderID)
        {
            var MainQuery = (from main in RepositoryContext.DemandOrder
                             where main.inactive == true && main.demandorderID == DemandOrderID
                             select new
                             {
                                 DemandOrderID = main.demandorderID,
                                 DeliveryDate = main.deliveryDate,
                                 DeliveryOrderDate = main.deliveryorderDate,
                                 customerID = main.customerID,
                                 bowserID = main.bowserID,
                                 driverID = main.driverID,
                                 status = main.status,
                                 data = (from detail in RepositoryContext.DemandOrderDetail
                                         join com in RepositoryContext.Compartment on detail.compartmentID equals com.compartmentID
                                         where detail.demandorderID == DemandOrderID
                                         select new
                                         {
                                             DemandOrderDetailID = detail.orderdetailID,
                                             CompartmentId = detail.compartmentID,
                                             Compartment = com.name,
                                             id = detail.productID,
                                             OrderLiter = detail.orderliter

                                         }).ToList()

                             });
            return MainQuery;
        }

        public dynamic GetDemandOrderNo()
        {
            string DemandOrderNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from corder in RepositoryContext.DemandOrder select corder.demandorderID).Count();
            if (count > 0)
            {
                maxDate = (from corder in RepositoryContext.DemandOrder select corder.demandorderID.Substring(5, 8)).Last();
                maxNO = (from corder in RepositoryContext.DemandOrder select corder.demandorderID.Substring(14, 17)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    DemandOrderNo = "DORD" + "-" + now + "-" + num;
                }
                else
                {
                    DemandOrderNo = "DORD" + "-" + now + "-" + "0001";
                }
            }
            else
            {
                DemandOrderNo = "DORD" + "-" + now + "-" + "0001";

            }
            return DemandOrderNo;
        }

        public dynamic GetAllDemandOrderListMoblie()
        {
            dynamic objResponse = null;

            try
            {

                var MainQuery = (from main in RepositoryContext.DemandOrder
                                 join driver in RepositoryContext.Driver on main.driverID equals driver.driverID
                                 join bowser in RepositoryContext.Bowser on main.bowserID equals bowser.bowserID
                                 where main.inactive == true
                                 select new
                                 {
                                     demandorderID = main.demandorderID,
                                     orderDate = main.deliveryorderDate,
                                     driverName = driver.name,
                                     carNo = bowser.carNo,
                                     deliveryDate = main.deliveryDate,

                                 }).ToList();
                objResponse = MainQuery;
            }
            catch (Exception ex)
            {
                objResponse = ex.Message;
            }
            return objResponse;
        }

        public dynamic GetAllDemandOrderListByCar(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj=param;
            int bowserID =obj.data;
            var MainQuery = (from main in RepositoryContext.DemandOrder
                             join driver in RepositoryContext.Driver on main.driverID equals driver.driverID
                             join bowser in RepositoryContext.Bowser on main.bowserID equals bowser.bowserID
                             join customer in RepositoryContext.Customer on main.customerID equals customer.customerID
                             where main.inactive == true && main.bowserID==bowserID
                             select new
                             {
                                 DemandOrderID = main.demandorderID,
                                 OrderDate = main.deliveryorderDate,
                                 DriverName = driver.name,
                                 CarNo = bowser.carNo,
                                 Customer = customer.customername,
                                 DeliveryDate = main.deliveryDate,

                             });
            return MainQuery.ToDataSourceResult(request);
        }
    }
}