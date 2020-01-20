using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class hw_tb1_registerRepo : RepositoryBase<hw_tb1_register>, Ihw_tb1_registerRepo
    {
        public hw_tb1_registerRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic Getregister(string password)
        {
            var result =(from register in RepositoryContext.hw_tb1_register
                        where register.password == password 
                        select new{
                            info =register.info
                        }).FirstOrDefault();
            return result;
        }
    }
}