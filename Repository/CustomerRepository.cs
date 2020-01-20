using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Ethereal_EM.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Customer> GetCustomerByLoginName(string loginName)
        {
            return FindByCondition(x => x.username == loginName).ToList();
        }

        public int CheckDuplicateCode(int customerID, string code)
        {
            return FindByCondition(x => x.customerID != customerID && x.code == code).Count();
        }

        public int CheckDuplicateEmail(int customerID, string Email)
        {
            return FindByCondition(x => x.customerID != customerID && x.email == Email).Count();
        }

        public int CheckDuplicatePhone(int customerID, string Phone)
        {
            return FindByCondition(x => x.customerID != customerID && x.phone == Phone).Count();
        }

        public int CheckDuplicateUserName(int customerID, string username)
        {
            return FindByCondition(x => x.customerID != customerID && x.username == username).Count();
        }

        public dynamic GetAllCustomerList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var MainQuery = (from main in RepositoryContext.Customer
                             where main.inactive == true
                             select new
                             {
                                 CustomerID = main.customerID,
                                 CustomerName = main.customername,
                                 Address = main.address,
                                 Phone = main.phone,
                                 Code = main.code,
                                 Email = main.email,
                                 main.access_status

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetCustomerCombo()
        {
            var query = (from customer in RepositoryContext.Customer
                         where customer.inactive == true
                         select new
                         {
                             Name = customer.customername,
                             CustomerID = customer.customerID,
                         });
            return query;
        }

        public dynamic GetCustomerData(int CustomerID)
        {
          
            var query = (from customer in RepositoryContext.Customer
                         where customer.customerID == CustomerID
                         select new
                         {
                             name = customer.customername,
                             code = customer.code,
                             customer.username,
                             Address = customer.address,
                             Phone = customer.phone,
                             TownshipID = customer.township,
                             StateID = customer.state,
                             Email = customer.email,
                             CustomerID = customer.customerID,
                             Password = customer.password,
                             ConfirmPassword = customer.password
                         });
            return query;
        }

        public dynamic GetProduct()
        {
            var query = (from product in RepositoryContext.Product
                         where product.inactive == true
                         select new
                         {
                             Name = product.productName,
                             ProductID = product.productID,
                             Liter = 0,
                             Price = 0
                         });
            return query;
        }

        public dynamic GetCustomerLoginMobile(string username)
        {
            dynamic objResponse = null;

            try
            {
                var MainQuery = (from sys in RepositoryContext.Customer
                                 where sys.username == username
                                 select new
                                 {
                                     username = sys.username,
                                     password = sys.password,
                                     customername = sys.customername,
                                     customerID = sys.customerID,
                                     customercode = sys.code,
                                     salt = sys.salt,
                                     login_fail_count = sys.login_fail_count,
                                     access_status = sys.access_status


                                 }).ToList();

                objResponse = MainQuery;
            }
            catch (Exception ex)
            {
                objResponse = ex.Message;
            }
            return objResponse;

        }

        public Customer FindById(int id)
        {
            return FindByID(id);
            /*
            var obj = RepositoryContext.Admin.Find(id);
            if (objcc
                obj.CopyOldObj();
            }
            return obj;*/
        }

        
    }
}