using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class MovementTransactionRepository : RepositoryBase<MovementTransaction>, IMovementTransactionRepository
    {
        public MovementTransactionRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetMovementProductData(string SupplierOrderID)
        {
            var MainQuery = (from main in RepositoryContext.MovementTransaction
                             where main.inactive == true && main.supplierOrderID == SupplierOrderID
                             select new
                             {

                                 ProductID = main.productID,
                                 FlowMeter = main.flowmeter,
                                 TLGStart = main.TLG_Start,
                                 TLGEnd = main.TLG_End,
                                 TLGVolume = main.TLG_Volume,

                             }).ToList();
            return MainQuery;
        }

        public dynamic GetMovementTransaction(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            string SupplierOrderID = obj.data;
            var MainQuery = (from main in RepositoryContext.MovementTransaction
                             where main.inactive == true && main.supplierOrderID == SupplierOrderID
                             select new
                             {
                                 MovementID = main.movementID,
                                 MovementDate = main.movementDate.ToString("yyyy-MM-dd"),
                                 tankID = main.tankID,
                                 id = main.productID,
                                 Product = (from p in RepositoryContext.Product
                                            where p.productID == main.productID
                                            select new
                                            {
                                                id = p.productID,
                                                Name = p.productName,
                                            }).ToList(),
                                 isNew = true,
                                 FlowMeter = main.flowmeter,
                                 TLGStart = main.TLG_Start,
                                 TLGEnd = main.TLG_End,
                                 TLGVolume = main.TLG_Volume,
                                 OnlyDelete = main.flowmeter != null ? true : false

                             });
            return MainQuery.ToDataSourceResult(request);
        }
    }
}