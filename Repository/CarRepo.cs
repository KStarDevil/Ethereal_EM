using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class CarRepo : RepositoryBase<carmodel>, ICarRepo
    {
        public CarRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool AnyByCondition(Expression<Func<CarRepo, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public dynamic ShowCarByID(int id)
        {
            var result = (from car in RepositoryContext.carmodel
                       where car.car_id == id
                       select car
            ).FirstOrDefault();

            return result;
        }

        public dynamic ShowCar(int id)
        {
            var result =(from car in RepositoryContext.carmodel
            where car.car_id == id
                        select new{
                            id = car.car_id,
                            name =car.car_name,
                            model = car.car_model,
                            produced=car.car_produced,
                            petrol = car.petrol,
                            gasoline = car.gasoline,
                            price = car.car_price
                        }).ToList();
            return result;
        }

        public IEnumerable<CarRepo> FindByCondition(Expression<Func<CarRepo, bool>> expression)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CarRepo> IRepositoryBase<CarRepo>.FindAll()
        {
            throw new NotImplementedException();
        }

        CarRepo IRepositoryBase<CarRepo>.FindByCompositeID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        CarRepo IRepositoryBase<CarRepo>.FindByCompositeID(int ID1, int ID2, int ID3)
        {
            throw new NotImplementedException();
        }

        CarRepo IRepositoryBase<CarRepo>.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        CarRepo IRepositoryBase<CarRepo>.FindByString(string ID)
        {
            throw new NotImplementedException();
        }

        
    }
}