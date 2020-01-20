using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetAllProduct(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);


            var MainQuery = (from main in RepositoryContext.Product
                             where main.inactive == true
                             select new
                             {
                                 id = main.productID,
                                 Name = main.productName,

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetProductCombo()
        {
            var MainQuery = (from main in RepositoryContext.Product
                             where main.inactive == true
                             select new
                             {
                                 id = main.productID,
                                 Name = main.productName,

                             }).ToList();
            return MainQuery;
        }

        public dynamic GetProductName(dynamic obj)
        {
            int productID = obj.data.productID;
            var MainQuery = (from main in RepositoryContext.Product
                             where main.inactive == true
                             select new
                             {
                                 id = main.productID,
                                 Name = main.productName,

                             }).ToList();
            if (productID != 0)
            {
                MainQuery = MainQuery.Where(x => x.id == productID).ToList();
            }
            return MainQuery;
        }

        dynamic IProductRepository.CheckDuplicateProductName(int productID, string productName)
        {
            return FindByCondition(x => x.productID != productID && x.productName == productName && x.inactive == true).Count();
        }
    }
}