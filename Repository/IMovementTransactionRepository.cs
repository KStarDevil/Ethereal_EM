using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface IMovementTransactionRepository:IRepositoryBase<MovementTransaction>
    {
        dynamic GetMovementTransaction(dynamic param);
        dynamic GetMovementProductData(string SupplierOrderID);
    }
}