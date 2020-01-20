using Ethereal_EM;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

        dynamic GetAllProduct(dynamic param);
        dynamic CheckDuplicateProductName(int productID, string productName);
        dynamic GetProductName(dynamic obj);
        dynamic GetProductCombo();

    }
}