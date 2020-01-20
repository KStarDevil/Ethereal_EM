using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ICustomerAssignRepository: IRepositoryBase<CustomerAssign>
    {
        dynamic GetCustomerAssignData(dynamic param);
        dynamic GetGainLossData(dynamic param,dynamic movement);
    }
}