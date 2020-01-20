using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ICustomerOrderDetailRepository: IRepositoryBase<CustomerOrderDetail>
    {
        dynamic GetCustomerOrderDetailNo();
    }
}