using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Ethereal_EM.Repository
{
    public class CustomerOrderDetailRepository : RepositoryBase<CustomerOrderDetail>, ICustomerOrderDetailRepository
    {
        public CustomerOrderDetailRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetCustomerOrderDetailNo()
        {
            string CustomerOrderDetailNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from detail in RepositoryContext.CustomerOrderDetail select detail.customerorderDetailID).Count();
            if (count > 0)
            {
                maxDate = (from detail in RepositoryContext.CustomerOrderDetail select detail.customerorderDetailID.Substring(3, 8)).Last();
                maxNO = (from detail in RepositoryContext.CustomerOrderDetail select detail.customerorderDetailID.Substring(12, 15)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    CustomerOrderDetailNo = "COI" + now + "-" + num;
                }
                else
                {
                    CustomerOrderDetailNo = "COI" + now + "-" + "0001";
                }
            }
            else
            {
                CustomerOrderDetailNo = "COI" + now + "-" + "0001";

            }
            return CustomerOrderDetailNo;
        }
    }
}