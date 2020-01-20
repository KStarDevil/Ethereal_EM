using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;

namespace Ethereal_EM.Repository
{
    public class CustomerAssignDetailRepository: RepositoryBase<CustomerAssignDetail>, ICustomerAssignDetailRepository
    {
        public CustomerAssignDetailRepository(AppDb repositoryContext)
            :base(repositoryContext)
        {
        }

    }
}