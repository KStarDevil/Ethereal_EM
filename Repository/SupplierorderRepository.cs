using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class SupplierorderRepository : RepositoryBase<SupplierOrder>, ISupplierorderRepository
    {
        public SupplierorderRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        public class SupplierOrderDetailData
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string SupplierOrderID { get; set; }
            public string SupplierName { get; set; }
            public string Status { get; set; }
            public double Balance { get; set; }
            public double Liter { get; set; }
            public double Week1 { get; set; }
            public double Week2 { get; set; }
            public double Week3 { get; set; }
            public double Week4 { get; set; }
            public string Shipment { get; set; }
            public DateTime ArrivalDate { get; set; }

        }
        public dynamic GetAllocateOrderList(string SupplierOrderID, dynamic param)
        {
            dynamic obj = param;
            var MainQuery = (from de in RepositoryContext.SupplierOrderDetail
                             join cu in RepositoryContext.SupplierOrder on de.supplierorderID equals cu.supplierOrderID
                             where de.inactive == true && de.supplierorderID == SupplierOrderID
                             select new
                             {

                                 SupplierName = cu.suppliername,
                                 SupplierOrderID = de.supplierorderID,
                                 Shipment = cu.shipment,
                                 Liter = de.liter,
                                 ProductID = de.productID,
                                 cu.arrivaldate,
                             }).ToList();

            if (obj.data.Month != "")
            {
                DateTime month = Convert.ToDateTime(obj.data.Month);
                MainQuery = MainQuery.Where(x => x.arrivaldate.Month == month.Month).ToList();
            }
            if (obj.data.shipment != "")
            {
                MainQuery = MainQuery.Where(x => x.Shipment.ToLower().Contains(obj.data.shipment.Value.ToLower())).ToList();
            }
            if (obj.data.suppliername != "")
            {
                string name = obj.data.suppliername.ToString();
                MainQuery = MainQuery.Where(x => x.SupplierName.ToLower().Contains(name.ToLower())).ToList();
            }

            return MainQuery;
        }

        public dynamic GetAllSupplierOrderList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            var MainQuery = (from main in RepositoryContext.SupplierOrder
                             where main.inactive == true
                             select new
                             {
                                 SupplierOrderID = main.supplierOrderID,
                                 Supplier = main.suppliername,
                                 ArrivalDate = main.arrivaldate,
                                 Shipment = main.shipment
                             });
            if (obj.data.FromDate.ToString() != "")
            {
                DateTime fromDate = obj.data.FromDate;
                MainQuery = MainQuery.Where(m => m.ArrivalDate >= fromDate);
            }
            if (obj.data.ToDate.ToString() != "")
            {
                DateTime toDate = obj.data.ToDate;
                MainQuery = MainQuery.Where(m => m.ArrivalDate <= toDate);
            }

            if (obj.data.supplierName.ToString() != "")
            {
                string supplierName = obj.data.supplierName;
                MainQuery = MainQuery.Where(m => m.Supplier.ToLower().Contains(supplierName));
            }
            if (obj.data.shipment.ToString() != "")
            {
                string shipment = obj.data.shipment;
                MainQuery = MainQuery.Where(m => m.Shipment.ToLower().Contains(shipment));
            }

            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetSupplierOrderData(string SupplierOrderID)
        {
            var query = (from main in RepositoryContext.SupplierOrder
                         where main.supplierOrderID == SupplierOrderID
                         select new
                         {
                             SupplierOrderID = main.supplierOrderID,
                             ArrivalDate = main.arrivaldate,
                             supplierName = main.suppliername,
                             shipment = main.shipment,
                             data = (from detail in RepositoryContext.SupplierOrderDetail
                                     join product in RepositoryContext.Product on detail.productID equals product.productID
                                     where detail.supplierorderID == SupplierOrderID
                                     select new
                                     {
                                         Name = product.productName,
                                         ID = detail.supplierorderdetailID,
                                         Liter = detail.liter,
                                         Price = detail.price,
                                         ProductID = detail.productID
                                     }).ToList()
                         });
            return query;
        }

        public dynamic GetSupplierOrderNo()
        {
            string SupplierOrderNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from supplierorder in RepositoryContext.SupplierOrder select supplierorder.supplierOrderID).Count();
            if (count > 0)
            {
                maxDate = (from supplierorder in RepositoryContext.SupplierOrder select supplierorder.supplierOrderID.Substring(5, 8)).Last();
                maxNO = (from supplierorder in RepositoryContext.SupplierOrder select supplierorder.supplierOrderID.Substring(14, 17)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    SupplierOrderNo = "SORD" + "-" + now + "-" + num;
                }
                else
                {
                    SupplierOrderNo = "SORD" + "-" + now + "-" + "0001";
                }
            }
            else
            {
                SupplierOrderNo = "SORD" + "-" + now + "-" + "0001";

            }
            return SupplierOrderNo;
        }

        public dynamic GetProductNameForSupplierOrder(dynamic productName, dynamic lstResult)
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
                        double Week1 = 0;
                        double Week2 = 0;
                        double Week3 = 0;
                        double Week4 = 0;
                        double Balance = 0;
                        string SupplierName = lstResult[j].SupplierName;
                        string Shipment = lstResult[j].Shipment;
                        name = SupplierName;
                        OrderID = lstResult[j].SupplierOrderID;
                        string ProductName = lstResult[j].ProductName;
                        int ProductID = lstResult[j].ProductID;
                        var count = (from c in RepositoryContext.CustomerAssign where c.supplierorderID == OrderID && c.inactive == true select c).Count();
                        if (count > 0)
                        {
                            Balance = (from c in RepositoryContext.CustomerAssign
                                       join cd in RepositoryContext.CustomerAssignDetail on c.customerassignID equals cd.customerassignID
                                       where c.supplierorderID == OrderID && c.productID == ProductID && c.inactive == true
                                       select cd.assignliter).Sum();
                        }
                        else
                        {
                            Balance = 0;
                        }
                        if (lstResult[j].ArrivalDate.Day <= 7)
                        {
                            Week1 = lstResult[j].Liter;
                        }
                        else if (lstResult[j].ArrivalDate.Day <= 14)
                        {
                            Week2 = lstResult[j].Liter;
                        }
                        else if (lstResult[j].ArrivalDate.Day <= 21)
                        {
                            Week3 = lstResult[j].Liter;
                        }
                        else if (lstResult[j].ArrivalDate.Day > 21)
                        {
                            Week4 = lstResult[j].Liter;
                        }

                        string SupplierOrderID = lstResult[j].SupplierOrderID;
                        obj["SupplierName"] = SupplierName;
                        obj["SupplierOrderID"] = SupplierOrderID;
                        obj["Shipment"] = Shipment;
                        obj["ArrivalDate"] = lstResult[j].ArrivalDate;
                        obj[ProductName + "_Week1"] = Week1;
                        obj[ProductName + "_Week2"] = Week2;
                        obj[ProductName + "_Week3"] = Week3;
                        obj[ProductName + "_Week4"] = Week4;
                        obj[ProductName + "ProductName"] = ProductName;
                        obj["ProductID"] = lstResult[j].ProductID;
                        obj[ProductName + "_Balance"] = Week1 != 0 ? Week1 - Balance : Week2 != 0 ? Week2 - Balance : Week3 != 0 ? Week3 - Balance : Week4 - Balance;
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
    }
}
