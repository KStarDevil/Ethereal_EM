using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Ethereal_EM.Repository
{
    public class SaleInvoiceRepository : RepositoryBase<SaleInvoice>, ISaleInvoiceRepository
    {
        public SaleInvoiceRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }


        public dynamic GetAllSaleInvoiceList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var Query = (from main in RepositoryContext.SaleInvoice
                        join customer in RepositoryContext.Customer on  main.customerID equals customer.customerID
                         where main.inactive == true && customer.inactive == true
                         select new
                         {
                             saleinvoiceID=main.saleinvoiceID,
                             invoiceDate= main.invoiceDate.ToString("yyyy-MM-dd"),
                             customername=customer.customername,
                             totalamount= main.totalamount,
                             Disamount=main.discount,
                             paidamount= main.netamount,

                         }
            );
            return Query.ToDataSourceResult(request);
        }
    }
}