using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Ethereal_EM.Repository
{
    public class CustomerAssignRepository : RepositoryBase<CustomerAssign>, ICustomerAssignRepository
    {
        public CustomerAssignRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetCustomerAssignData(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            string SupplierOrderID = obj.data.SupplierOrderID;
            int ProductID = obj.data.ProductID;
            DateTime Date = obj.data.Month;
            var MainQuery = from result in (from cu in RepositoryContext.CustomerAssign
                                            join cud in RepositoryContext.CustomerAssignDetail on cu.customerassignID equals cud.customerassignID
                                            join cod in RepositoryContext.CustomerOrder on cud.customerOrderID equals cod.customerOrderID
                                            where cu.supplierorderID == SupplierOrderID && cu.assignweek == Date && cu.productID == ProductID && cu.inactive == true
                                            select new
                                            {
                                                CustomerAssignID = cu.customerassignID,
                                                CustomerOrderID = cud.customerOrderID,
                                                CustomerName = RepositoryContext.Customer.Where(x => x.customerID == cod.customerID).Select(x => x.customername).FirstOrDefault(),
                                                OrderLiter = cud.orderliter,
                                                AssignLiter = cud.assignliter
                                            })
                            group result by new { result.CustomerOrderID } into t1
                            select new
                            {
                                CustomerOrderID = t1.Key.CustomerOrderID,
                                t1.FirstOrDefault().CustomerName,
                                t1.FirstOrDefault().CustomerAssignID,
                                t1.FirstOrDefault().OrderLiter,
                                AssignLiter = (t1.Sum(x => x.AssignLiter)),
                                OrderBalance = t1.FirstOrDefault().OrderLiter - (t1.Sum(x => x.AssignLiter))
                            };
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetGainLossData(dynamic param, dynamic movement)
        {
            dynamic obj = param;
            string SupplierOrderID = obj.data;
            List<dynamic> list = new List<dynamic>();

            for (int i = 0; i < movement.Count; i++)
            {

                int ProductID = movement[i].ProductID;
                var query = (from customerassign in RepositoryContext.CustomerAssign
                             join cd in RepositoryContext.CustomerAssignDetail on customerassign.customerassignID equals cd.customerassignID
                             join p in RepositoryContext.Product on customerassign.productID equals p.productID
                             join customerorder in RepositoryContext.CustomerOrder on cd.customerOrderID equals customerorder.customerOrderID
                             join cu in RepositoryContext.Customer on customerorder.customerID equals cu.customerID
                             where customerassign.supplierorderID == SupplierOrderID && customerassign.productID == ProductID
                             select new
                             {
                                 CustomerOrderID = cd.customerOrderID,
                                 AssignLiter = cd.assignliter,
                                 OrderLiter = cd.orderliter,
                                 CustomerName = cu.customername,
                                 Product = p.productName

                             }).ToList();
                for (int j = 0; j < query.Count; j++)
                {
                    Newtonsoft.Json.Linq.JObject data = new Newtonsoft.Json.Linq.JObject();
                    data["CustomerOrderID"] = query[j].CustomerOrderID;
                    data["OrderLiter"] = query[j].OrderLiter;
                    data["ShipLiter"] = query[j].AssignLiter;
                    data["CustomerName"] = query[j].CustomerName;
                    data["Product"] = query[j].Product;
                    data["GainLoss"] = (movement[i].TLGVolume / 100).ToString() + "%";
                    data["ActualLiter"] = query[j].AssignLiter + (query[j].AssignLiter * ((movement[i].TLGVolume / 100) / 100));
                    list.Add(data);
                }

            }
            return list;
        }
    }
}