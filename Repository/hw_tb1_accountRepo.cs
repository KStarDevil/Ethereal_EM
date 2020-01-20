using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class hw_tb1_accountRepo : RepositoryBase<hw_tb1_account>, Ihw_tb1_accountRepo
    {
        public hw_tb1_accountRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic Getaccount(string name)
        {
            var result =(from account in RepositoryContext.hw_tb1_account 
                        where account.name == name 
                        select new{
                            password =account.password
                        }).FirstOrDefault();
            return result;
        }
    }
}