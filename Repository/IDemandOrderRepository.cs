using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface IDemandOrderRepository: IRepositoryBase<DemandOrder>
    {
        dynamic GetDemandOrderNo();
        dynamic GetAllDemandOrderList(dynamic param);
        dynamic GetDemandOrderData(string DemandOrderID);

         dynamic GetAllDemandOrderListMoblie();
         dynamic GetAllDemandOrderListByCar(dynamic param);
    }
}