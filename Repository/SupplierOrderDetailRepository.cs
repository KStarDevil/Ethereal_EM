using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Ethereal_EM.Repository
{
    public class SupplierOrderDetailRepository: RepositoryBase<SupplierOrderDetail>, ISupplierOrderDetailRepository
    {
        public SupplierOrderDetailRepository(AppDb repositoryContext)
            :base(repositoryContext)
        {
        }

        public dynamic GetSupplierOrderDetailNo()
        {
            string SupplierOrderDetailNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from detail in RepositoryContext.SupplierOrderDetail select detail.supplierorderdetailID).Count();
            if (count > 0)
            {
                maxDate = (from detail in RepositoryContext.SupplierOrderDetail select detail.supplierorderdetailID.Substring(3, 8)).Last();
                maxNO = (from detail in RepositoryContext.SupplierOrderDetail select detail.supplierorderdetailID.Substring(12, 15)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    SupplierOrderDetailNo = "SOI"+ now + "-" + num;
                }
                else
                {
                    SupplierOrderDetailNo = "SOI"+ now + "-" + "0001";
                }
            }
            else
            {
               SupplierOrderDetailNo = "SOI"+ now + "-" + "0001";

            }
            return SupplierOrderDetailNo;
        }
    }
}