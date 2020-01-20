using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ICustomerOrderRepository: IRepositoryBase<CustomerOrder>
    {
        dynamic GetCustomerproduct();
        dynamic GetCustomerOrderNo();
        dynamic GetAllCustomerOrderList(string CustomerOrderID,dynamic param);
        dynamic GetCustomerOrderData(string CustomerOrderID);
        dynamic GetHeaderList(dynamic obj);
        dynamic GetProductNameForCustomerOrder(dynamic productName , dynamic lstResult);
        dynamic GetCustomerOrderByMonth(dynamic param);
        dynamic GetCustomerAssignOrderByMonth(dynamic param);
         dynamic GetAllCustomerOrderListMoblie();
    }
}