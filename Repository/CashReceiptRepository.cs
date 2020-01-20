using System;
using System.Collections.Generic;
using Kendo.Mvc.UI;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class CashReceiptRepository : RepositoryBase<CashReceipt>, ICashReceiptRepository
    {
        public CashReceiptRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetAllCashRecriptList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var Query = (from main in RepositoryContext.CashReceipt
                        // join SaleInvoice in RepositoryContext.SaleInvoice on main.saleinvoiceID equals SaleInvoice.saleinvoiceID
                         join customer in RepositoryContext.Customer on main.customerID equals customer.customerID
                         where main.inactive == true && customer.inactive == true
                         select new
                         {
                             cashreceiptID=main.cashreceiptID,
                             saleinvoiceID = main.saleinvoiceID,
                             invoiceDate = main.paymentDate.ToString("yyyy-MM-dd"),
                             customername = customer.customername,
                             netamount = main.netAmount,
                             balance = main.balance,
                             paidamount = main.paidAmount,
                         }
            );
            return Query.ToDataSourceResult(request);
        }

         public  dynamic GetCashReceiptEditList(string cashreceiptid)
        {
           
            var Query = (from main in RepositoryContext.CashReceipt
                        // join SaleInvoice in RepositoryContext.SaleInvoice on main.saleinvoiceID equals SaleInvoice.saleinvoiceID
                        // join customer in RepositoryContext.Customer on main.customerID equals customer.customerID
                         where main.inactive == true && main.cashreceiptID == cashreceiptid
                         select new
                         {
                             cashreceiptID=main.cashreceiptID,
                             saleinvoiceID = main.saleinvoiceID,
                             invoiceDate = main.paymentDate.ToString("yyyy-MM-dd"),
                            //  customername = customer.customername,
                             netamount = main.netAmount,
                             balance = main.balance,
                             paidamount = main.paidAmount,
                         }
            );
            return Query.ToList();
        }
    }
}