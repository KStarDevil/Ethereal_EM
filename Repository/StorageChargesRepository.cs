using System;
using System.Collections.Generic;
using Ethereal_EM;
using System.Linq;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class StorageChargesRepository : RepositoryBase<StorageCharges>, IStorageChargesRepository
    {
        public StorageChargesRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetStorageCharges(int CustomerID)
        {
            var query = (from main in RepositoryContext.StorageCharges
                         join product in RepositoryContext.Product on main.productID equals product.productID
                         where main.customerID == CustomerID
                         select new
                         {
                             ProductID = main.productID,
                             Price = main.charges,
                             ID = main.storagechargeID,
                             Name = product.productName
                         });
            return query;
        }
    }
}