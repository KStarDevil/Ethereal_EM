using System;
using System.Collections.Generic;
using Ethereal_EM;

namespace Ethereal_EM.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        int CheckDuplicateCode(int customerID, string code);
        int CheckDuplicateUserName(int customerID, string username);
        int CheckDuplicateEmail(int customerID, string Email);
        int CheckDuplicatePhone(int customerID, string Phone);
        dynamic GetAllCustomerList(dynamic param);
        dynamic GetCustomerData(int CustomerID);
        
        dynamic GetProduct();
         dynamic GetCustomerCombo();
         dynamic GetCustomerLoginMobile(string username); //*  Min Htet Aung Adding for Customer Login to Get Customer Detail
         Customer FindById(int id); //*  Min Htet Aung Adding for Customer Login 
         IEnumerable<Customer> GetCustomerByLoginName(string loginName);
    }
}