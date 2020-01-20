using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ISupplierorderRepository:IRepositoryBase<SupplierOrder>
    {
        dynamic GetSupplierOrderNo();
        dynamic GetAllSupplierOrderList(dynamic param);
        dynamic GetSupplierOrderData(string SupplierOrderID);
        dynamic GetAllocateOrderList(string SupplierOrderID, dynamic param);
         dynamic GetProductNameForSupplierOrder(dynamic productName , dynamic lstResult);
    }
}