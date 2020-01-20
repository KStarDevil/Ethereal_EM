using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class hw_tb1_userRepo : RepositoryBase<hw_tb1_user>, Ihw_tb1_userRepo
    {
        public hw_tb1_userRepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetUser(int id)
        {
            var result =(from user in RepositoryContext.hw_tb1_user 
                        where user.id == id 
                        select new{
                            name =user.name
                        }).FirstOrDefault();
            return result;
        }

        IEnumerable<hw_tb1_user> IRepositoryBase<hw_tb1_user>.FindAll()
        {
            throw new NotImplementedException();
        }

        hw_tb1_user IRepositoryBase<hw_tb1_user>.FindByCompositeID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        hw_tb1_user IRepositoryBase<hw_tb1_user>.FindByCompositeID(int ID1, int ID2, int ID3)
        {
            throw new NotImplementedException();
        }

        hw_tb1_user IRepositoryBase<hw_tb1_user>.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        hw_tb1_user IRepositoryBase<hw_tb1_user>.FindByString(string ID)
        {
            throw new NotImplementedException();
        }
    }
}