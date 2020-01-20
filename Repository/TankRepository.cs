using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class TankRepository : RepositoryBase<Tank>, ITankRepository
    {
        public TankRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }



        public dynamic GetTankDataList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            dynamic objresponse = null;

            var Main = (from Tanklist in RepositoryContext.Tank
                        where Tanklist.inactive == true
                        select new
                        {

                            TankID = Tanklist.tankID,
                            TankName = Tanklist.tankname,
                            ProductID = Tanklist.productID,
                            ProductName = RepositoryContext.Product.Where(a => a.productID == Tanklist.productID && a.inactive == true).Select(a => a.productName).FirstOrDefault(),
                            // TGLAddress = Tanklist.TLG_Address,
                            // TempperatureAddress= Tanklist.temperatureAddress,
                            // Balance = Tanklist.tankID,
                            // Temperature = Tanklist.tankID,
                            // TLGStatus = Tanklist.tankID,

                        });
            return objresponse = Main.ToDataSourceResult(request);
        }
        public dynamic GetTankUpdate(int tankID)
        {
            dynamic objresponse = null;

            var Main = (from Tanklist in RepositoryContext.Tank
                        where Tanklist.inactive == true && Tanklist.tankID == tankID
                        select new
                        {

                            tankID = Tanklist.tankID,
                            TankName = Tanklist.tankname,
                            PetrolType = Tanklist.productID,
                            TLGAddress = Tanklist.TLG_Address,
                            TempperatureAddress = Tanklist.temperatureAddress,
                            // Balance = Tanklist.tankID,
                            // Temperature = Tanklist.tankID,
                            // TLGStatus = Tanklist.tankID,

                        });
            return objresponse = Main.ToList();

        }


        public dynamic GetListPetrol()
        {
            var Main = (from Product in RepositoryContext.Product
                        where Product.inactive == true
                        select new
                        {
                            id = Product.productID,
                            name = Product.productName

                        }).ToList();
            return Main.ToList();
        }

        public dynamic GetTankCombo()
        {
            var query = (from tank in RepositoryContext.Tank
                         where tank.inactive == true
                         select new
                         {
                             tank.tankID,
                             tank.tankname,
                             tank.productID,
                         });
            return query;
        }

        public dynamic GetProductName(int TankID)
        {
            var query = (from tank in RepositoryContext.Tank
                         join product in RepositoryContext.Product on tank.productID equals product.productID
                         where tank.tankID == TankID
                         select new
                         {
                            id = product.productID,
                            Name= product.productName
                         });
            return query;
        }
    }
}