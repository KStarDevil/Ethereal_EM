using System.Linq;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class AccountRepo : RepositoryBase<AccountModel>, IAccountRepo
    {
        public AccountRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        //Left Join
        // public dynamic GetAccount(int id)
        // {
        //    var acc = (from v in RepositoryContext.Account
                        
        //                 join company1 in RepositoryContext.Company1 on v.A_ID equals company1.id
        //                 join department in RepositoryContext.Department on v.A_ID equals department.D_ID
        //                 where v.A_ID == id                           
        //                      select new
        //                      {
        //                         Account_ID= v.A_ID,
        //                         Account_Name=v.A_Name,
        //                         Account_Password=v.A_Password,
        //                         Account_Device=v.A_Device,
        //                         Account_NRC=v.A_NRC,
        //                         Account_Phone=v.A_Phone,

        //                         company_id=company1.id,
        //                         company1_name=company1.C_Name,
        //                         company1_Phone=company1.C_Phone,
        //                         company1_Address=company1.C_Address,
        //                         company1_Description=company1.C_Description,

        //                         department_id=department.D_ID,
        //                         department_Name=department.D_Name,
        //                         department_Location=department.D_Location,
        //                         department_Description=department.D_Description,

        //                      }
        //                      ).ToList();

        //     return acc;
        // }

        public dynamic GetAccount(string name)
        {
            throw new System.NotImplementedException();
        }
        //Right Join
        // public dynamic GetAccount(int id)
        // {
        //    var acc = (from Company1 in RepositoryContext.Company1
                        
        //                 join account in RepositoryContext.Account on Company1.id equals account.A_ID
        //                 // join department in RepositoryContext.Department on v.A_ID equals department.D_ID
        //                 where Company1.id == id                           
        //                      select new
        //                      {
        //                         Account_ID= account.A_ID,
        //                         Account_Name=account.A_Name,
        //                         Account_Password=account.A_Password,
        //                         Account_Device=account.A_Device,
        //                         Account_NRC=account.A_NRC,
        //                         Account_Phone=account.A_Phone,

        //                         company_id=Company1.id,
        //                         company1_name=Company1.C_Name,
        //                         company1_Phone=Company1.C_Phone,
        //                         company1_Address=Company1.C_Address,
        //                         company1_Description=Company1.C_Description,

        //                         // department_id=department.D_ID,
        //                         // department_Name=department.D_Name,
        //                         // department_Location=department.D_Location,
        //                         // department_Description=department.D_Description,

        //                      }
        //                      ).ToList();

        //     return acc;
        // }
        
        // Outer Join
        public dynamic GetAccount(int id)
        {
           var acc = (from Company1 in RepositoryContext.Company1
                        
                        join account in RepositoryContext.Account on Company1.id equals account.A_ID
                        // join department in RepositoryContext.Department on v.A_ID equals department.D_ID
                        orderby account.A_ID descending
                        // where Company1.id == id                           
                             select new
                             {
                                Account_ID= account.A_ID,
                                Account_Name=account.A_Name,
                                Account_Password=account.A_Password,
                                Account_Device=account.A_Device,
                                Account_NRC=account.A_NRC,
                                Account_Phone=account.A_Phone,

                                company_id=Company1.id,
                                company1_name=Company1.C_Name,
                                company1_Phone=Company1.C_Phone,
                                company1_Address=Company1.C_Address,
                                company1_Description=Company1.C_Description,

                                // department_id=department.D_ID,
                                // department_Name=department.D_Name,
                                // department_Location=department.D_Location,
                                // department_Description=department.D_Description,

                             }
                             ).ToList();

            return acc;
        }
    }
}