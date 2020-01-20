using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        public class CustomerOrderDetailData
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string CustomerOrderID { get; set; }
            public string CustomerName { get; set; }
            public string OrderMonth { get; set; }
            public string Status { get; set; }
            public double Total { get; set; }
            public double Week1 { get; set; }
            public double Week2 { get; set; }
            public double Week3 { get; set; }
            public double Week4 { get; set; }

        }
        public dynamic GetAllCustomerOrderList(string CustomerOrderID, dynamic param)
        {
            dynamic obj = param;
            var MainQuery = (from de in RepositoryContext.CustomerOrderDetail
                             join cu in RepositoryContext.CustomerOrder on de.customerOrderID equals cu.customerOrderID
                             where de.inactive == true && de.customerOrderID == CustomerOrderID
                             select new
                             {
                                 CustomerID = RepositoryContext.CustomerOrder.Where(x => x.customerOrderID == CustomerOrderID).Select(x => x.customerID).FirstOrDefault(),
                                 CustomerName = RepositoryContext.Customer.Where(x => x.customerID == cu.customerID).Select(x => x.customername).FirstOrDefault(),
                                 CustomerOrderID = de.customerOrderID,
                                 Total = de.total,
                                 cu.ordermonth,
                                 ProductID = de.productID,
                                 Week1 = de.week1_liter,
                                 Week2 = de.week2_liter,
                                 Week3 = de.week3_liter,
                                 Week4 = de.week4_liter,
                                 cu.status
                             }).ToList();
            if (obj.data.productID != 0)
            {
                MainQuery = MainQuery.Where(x => x.ProductID == obj.data.productID.Value).ToList();
            }
            if (obj.data.Month != "")
            {
                DateTime month = Convert.ToDateTime(obj.data.Month);
                MainQuery = MainQuery.Where(x => x.ordermonth == month).ToList();
            }
            if (obj.data.customerorderNo != "")
            {
                MainQuery = MainQuery.Where(x => x.CustomerOrderID.ToLower().Contains(obj.data.customerorderNo.Value.ToLower())).ToList();
            }
            if (obj.data.customername != "")
            {
                string name = obj.data.customername.ToString();
                MainQuery = MainQuery.Where(x => x.CustomerName.ToLower().Contains(name.ToLower())).ToList();
            }
            if (obj.data.status != "0")
            {
                int status = Int32.Parse(obj.data.status.Value);
                MainQuery = MainQuery.Where(x => x.status == status).ToList();
            }
            return MainQuery;
        }

        public dynamic GetCustomerOrderNo()
        {
            string CustomerOrderNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from corder in RepositoryContext.CustomerOrder select corder.customerOrderID).Count();
            if (count > 0)
            {
                maxDate = (from corder in RepositoryContext.CustomerOrder select corder.customerOrderID.Substring(5, 8)).Last();
                maxNO = (from corder in RepositoryContext.CustomerOrder select corder.customerOrderID.Substring(14, 17)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    CustomerOrderNo = "CORD" + "-" + now + "-" + num;
                }
                else
                {
                    CustomerOrderNo = "CORD" + "-" + now + "-" + "0001";
                }
            }
            else
            {
                CustomerOrderNo = "CORD" + "-" + now + "-" + "0001";

            }
            return CustomerOrderNo;
        }

        public dynamic GetCustomerproduct()
        {
            var query = (from product in RepositoryContext.Product
                         where product.inactive == true
                         select new
                         {
                             Name = product.productName,
                             ProductID = product.productID,
                             Week1 = 0,
                             Week2 = 0,
                             Week3 = 0,
                             Week4 = 0,
                             Total = 0,
                             ID = "0",
                             Remark = ""
                         });
            return query;
        }

        public dynamic GetHeaderList(dynamic obj)
        {
            int productID = obj.productID;
            var Products = (from p in RepositoryContext.Product
                            where p.inactive == true
                            select new
                            {
                                p.productID,
                                p.productName,
                            }).ToList();
            if (productID != 0)
            {
                Products = Products.Where(x => x.productID == productID).ToList();
            }

            return Products;

        }

        public dynamic GetProductNameForCustomerOrder(dynamic productName, dynamic lstResult)
        {
            // List<TbTaEmployeeLeaveBalance> EmployeeLeaveBal = new List<TbTaEmployeeLeaveBalance>();
            dynamic objresponse = null;
            dynamic lstobjBalance = null;
            List<dynamic> lstobj = new List<dynamic>();
            List<int> containedID = new List<int>();
            string name = "";
            string OrderID = "";
            Newtonsoft.Json.Linq.JObject obj = new Newtonsoft.Json.Linq.JObject();

            for (int k = 0; k < productName.Count; k++)
            {
                for (int j = 0; j < lstResult.Count; j++)
                {
                    if (productName[k].Name.ToString() == lstResult[j].ProductName)
                    {
                        string CustomerName = lstResult[j].CustomerName;
                        name = CustomerName;
                        OrderID = lstResult[j].CustomerOrderID;
                        string ProductName = lstResult[j].ProductName;
                        double Week1 = lstResult[j].Week1;
                        double Week2 = lstResult[j].Week2;
                        double Week3 = lstResult[j].Week3;
                        double Week4 = lstResult[j].Week4;
                        double Total = lstResult[j].Total;
                        string CustomerOrderID = lstResult[j].CustomerOrderID;
                        obj["CustomerName"] = CustomerName;
                        obj["CustomerOrderID"] = CustomerOrderID;
                        obj["Status"] = lstResult[j].Status;
                        obj["Month"] = lstResult[j].OrderMonth;
                        obj[ProductName + "_Week1"] = Week1;
                        obj[ProductName + "_Week2"] = Week2;
                        obj[ProductName + "_Week3"] = Week3;
                        obj[ProductName + "_Week4"] = Week4;
                        obj[ProductName + "_Total"] = Total;
                        containedID.Add(productName[k].id);
                        /*      if (productName[k].Name.ToString() != lstResult[j].ProductName)
                             {
                                  employeename = lstResult[j].EmployeeName;
                                 ProductName = lstResult[j].ProductName;
                                 Week1 = 0;
                                 Week2 = 0;
                                 Week3 = 0;
                                 Week4 = 0;
                                 Total = 0;
                                 obj["EmployeeName"] = employeename;
                                 obj[ProductName + "_Week1"] = Week1;
                                 obj[ProductName + "_Week2"] = Week2;
                                 obj[ProductName + "_Week3"] = Week3;
                                 obj[ProductName + "_Week4"] = Week4;
                                 obj[ProductName + "_Total"] = Total;
                                 lstobjBalance = obj;
                                 break;
                             } */
                        lstobjBalance = obj;
                        //break;
                    }
                    /*  else
                     {
                          string employeename = lstResult[j].EmployeeName;
                         string ProductName = lstResult[j].ProductName;
                         double Week1 = 0;
                         double Week2 = 0;
                         double Week3 = 0;
                         double Week4 = 0;
                         double Total = 0;
                         obj["EmployeeName"] = employeename; 
                         obj[ProductName + "_Week1"] = Week1;
                         obj[ProductName + "_Week2"] = Week2;
                         obj[ProductName + "_Week3"] = Week3;
                         obj[ProductName + "_Week4"] = Week4;
                         obj[ProductName + "_Total"] = Total;
                         lstobjBalance = obj;
                     } */
                }

            }
            for (int g = 0; g < productName.Count; g++)
            {
                if (!containedID.Contains(productName[g].id))
                {

                    string ProductName = productName[g].Name;
                    string CustomerOrderID = OrderID;
                    obj["CustomerName"] = name;
                    obj["CustomerOrderID"] = CustomerOrderID;
                    obj[ProductName + "_Week1"] = 0;
                    obj[ProductName + "_Week2"] = 0;
                    obj[ProductName + "_Week3"] = 0;
                    obj[ProductName + "_Week4"] = 0;
                    obj[ProductName + "_Total"] = 0;
                }
            }
            return objresponse = lstobjBalance;



        }

        public dynamic GetCustomerOrderData(string CustomerOrderID)
        {
            var query = (from main in RepositoryContext.CustomerOrder
                         where main.customerOrderID == CustomerOrderID
                         select new
                         {
                             CustomerOrderID = main.customerOrderID,
                             OrderMonth = main.ordermonth,
                             customerID = main.customerID,
                             main.status,
                             data = (from detail in RepositoryContext.CustomerOrderDetail
                                     join product in RepositoryContext.Product on detail.productID equals product.productID
                                     where detail.customerOrderID == CustomerOrderID
                                     select new
                                     {
                                         Name = product.productName,
                                         ID = detail.customerorderDetailID,
                                         Week1 = detail.week1_liter,
                                         Week2 = detail.week2_liter,
                                         Week3 = detail.week3_liter,
                                         Week4 = detail.week4_liter,
                                         Remark = detail.remark,
                                         Total = detail.total,
                                         ProductID = detail.productID
                                     }).ToList()
                         });
            return query;
        }

        public dynamic GetCustomerOrderByMonth(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            int ProductID = obj.data.ProductID;
            DateTime Date = obj.data.Month;
            string SupplierOrderID = obj.data.SupplierOrderID;
            int Month = Date.Month;
            int Year = Date.Year;
            int Day = Date.Day;
             var query = (from cu in RepositoryContext.CustomerAssign
                         join cd in RepositoryContext.CustomerAssignDetail on cu.customerassignID equals cd.customerassignID
                         where cu.inactive == true && cu.supplierorderID == SupplierOrderID && cu.productID == ProductID && cu.assignweek.Month == Month && cu.assignweek.Year == Year
                         select cd.customerOrderID).ToList();
            string[] customerOrderIDArray = query.ToArray();

            var MainQuery = (from de in RepositoryContext.CustomerOrderDetail
                             join cu in RepositoryContext.CustomerOrder on de.customerOrderID equals cu.customerOrderID
                             where cu.inactive == true && de.productID == ProductID && cu.ordermonth.Month == Month && cu.ordermonth.Year == Year  && !customerOrderIDArray.Contains(de.customerOrderID)
                             select new
                             {
                                 CustomerOrderID = cu.customerOrderID,
                                 CustomerName = RepositoryContext.Customer.Where(x => x.customerID == cu.customerID).Select(x => x.customername).FirstOrDefault(),
                                 OrderLiter = Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter,
                                 OrderBalance = (from c in RepositoryContext.CustomerAssign
                                                 join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                                 where cd.customerOrderID == de.customerOrderID && c.productID == ProductID && c.assignweek.Month == Month && c.assignweek.Day == Day && c.inactive == true
                                                 select c.customerassignID).Count() > 0 ? (Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter) - (from c in RepositoryContext.CustomerAssign
                                                                                                                                                                                                    join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                                                                                                                                                                                    where cd.customerOrderID == de.customerOrderID && c.productID == ProductID && c.assignweek.Month == Month && c.assignweek.Day == Day && c.inactive == true
                                                                                                                                                                                                    select cd.assignliter).Sum() : Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter
                             });
            return MainQuery.ToDataSourceResult(request);

        }

        public dynamic GetCustomerAssignOrderByMonth(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            int ProductID = obj.data.ProductID;
            DateTime Date = obj.data.Month;
            int Month = Date.Month;
            int Year = Date.Year;
            int Day = Date.Day;
            string[] CustomerOrderID = obj.data.selectedOrder.Value.Split(",");
           
            var MainQuery = (from de in RepositoryContext.CustomerOrderDetail
                             join cu in RepositoryContext.CustomerOrder on de.customerOrderID equals cu.customerOrderID
                             where cu.inactive == true && de.productID == ProductID && cu.ordermonth.Month == Month && cu.ordermonth.Year == Year && CustomerOrderID.Contains(de.customerOrderID)
                             select new
                             {
                                 CustomerAssignID = 0,
                                 CustomerOrderID = cu.customerOrderID,
                                 CustomerName = RepositoryContext.Customer.Where(x => x.customerID == cu.customerID).Select(x => x.customername).FirstOrDefault(),
                                 OrderLiter = Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter,
                                 AssignLiter = 0,
                                 tt = (from c in RepositoryContext.CustomerAssign
                                       join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                       where cd.customerOrderID == de.customerOrderID && c.productID == ProductID
                                       select cd.assignliter).FirstOrDefault(),
                                 OrderBalance = (from c in RepositoryContext.CustomerAssign
                                                 join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                                 where cd.customerOrderID == de.customerOrderID && c.productID == ProductID && c.assignweek.Month == Month && c.assignweek.Day == Day && c.inactive == true
                                                 select c.customerassignID).Count() > 0 ? (Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter) - (from c in RepositoryContext.CustomerAssign
                                                                                                                                                                                                    join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                                                                                                                                                                                    where cd.customerOrderID == de.customerOrderID && c.productID == ProductID && c.assignweek.Month == Month && c.assignweek.Day == Day && c.inactive == true
                                                                                                                                                                                                    select cd.assignliter).Sum() : Day <= 7 ? de.week1_liter : Day <= 14 ? de.week2_liter : Day <= 21 ? de.week3_liter : de.week4_liter
                             });
            var aa = MainQuery.ToList();
            return MainQuery.ToDataSourceResult(request);
        }
        public dynamic GetAllCustomerOrderListMoblie()
        {
            dynamic objResponse = null;

            try
            {

                var MainQuery = (from main in RepositoryContext.CustomerOrder
                                 where main.inactive == true
                                 select new
                                 {
                                     customerOrderID = main.customerOrderID,
                                     ordermonth = main.ordermonth,
                                     remark = main.remark,
                                     //status = main.status,
                                     //userType = main.userType,
                                     //createuser = main.createuser,
                                     //modifieddate = main.modifieddate,
                                     //inactive = main.inactive

                                 }).ToList();
                objResponse = MainQuery;
            }
            catch (Exception ex)
            {
                objResponse = ex.Message;
            }
            return objResponse;
        }
    }
}