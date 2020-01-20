using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class LaneRepository : RepositoryBase<Lane>, ILaneRepository
    {
        public LaneRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic CheckDuplicate(int LaneID, string name)
        {
           return FindByCondition(x => x.laneID != LaneID && x.laneName == name && x.inactive==true).Count();
        }

        public dynamic GetLaneDataList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            dynamic objresponse = null;

            var Main = (from lane in RepositoryContext.Lane

                        where lane.inactive == true
                        select new
                        {

                            LaneID = lane.laneID,
                            LaneName = lane.laneName,
                            HoseNo = string.Join(",", RepositoryContext.Hose.Where(a => a.laneID == lane.laneID && a.inactive == true).Select(a => a.hoseNumber).ToArray()),

                        });

            return objresponse = Main.ToDataSourceResult(request);
        }

        public dynamic GetLaneEditData(int ID)
        {
            var Main = (from lane in RepositoryContext.Lane

                        where lane.inactive == true && lane.laneID == ID
                        select new
                        {
                            LaneID = lane.laneID,
                            LaneName = lane.laneName,
                            item = (from Lane in RepositoryContext.Lane
                                    join hose in RepositoryContext.Hose on Lane.laneID equals hose.laneID
                                    where hose.laneID == ID && hose.inactive == true
                                    select new
                                    {
                                        LaneID = lane.laneID,
                                        hoseID = hose.hoseID,
                                        HoseNo = hose.hoseNumber,
                                        productID = hose.productID,
                                        FlowMeterAddress = hose.flowmeter,
                                    }).ToArray()


                        });
            var aa = Main.ToList();
            return Main;

        }

        public dynamic GetPetrolList()
        {
            var Main = (from Product in RepositoryContext.Product
                        where Product.inactive == true
                        select new
                        {
                            productID = Product.productID,
                            name = Product.productName

                        }).ToList();
            return Main.ToList();
        }
    }
}