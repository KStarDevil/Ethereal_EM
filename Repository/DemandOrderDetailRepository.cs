using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
namespace Ethereal_EM.Repository
{
    public class DemandOrderDetailRepository: RepositoryBase<DemandOrderDetail>, IDemandOrderDetailRepository
    {
        public DemandOrderDetailRepository(AppDb repositoryContext)
            :base(repositoryContext)
        {
        }

        public dynamic GetDemandOrderDetailNo()
        {
           string DemandOrderDetailNo = "";
            string maxNO = "";
            int max = 0;
            string maxDate = "";
            string now = System.DateTime.Now.ToString("yyyyMMdd");
            var count = (from detail in RepositoryContext.DemandOrderDetail select detail.orderdetailID).Count();
            if (count > 0)
            {
                maxDate = (from detail in RepositoryContext.DemandOrderDetail select detail.orderdetailID.Substring(3, 8)).Last();
                maxNO = (from detail in RepositoryContext.DemandOrderDetail select detail.orderdetailID.Substring(12, 15)).Last();

                if (maxDate == now)
                {
                    max = int.Parse(maxNO) + 1;
                    var invNo = (max).ToString();
                    var num = string.Format("{0:0000}", int.Parse(invNo));
                    DemandOrderDetailNo = "DOI" + now + "-" + num;
                }
                else
                {
                    DemandOrderDetailNo = "DOI" + now + "-" + "0001";
                }
            }
            else
            {
                DemandOrderDetailNo = "DOI" + now + "-" + "0001";

            }
            return DemandOrderDetailNo;
        }
    }
}