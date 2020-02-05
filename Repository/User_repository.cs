using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class User_Repository : RepositoryBase<User>, IUser_Repository
    {
        public User_Repository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool AnyByCondition(Expression<Func<tbl_user, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbl_user> FindByCondition(Expression<Func<tbl_user, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public dynamic Get_all_user()
        {
            var query = (from User in RepositoryContext.tbl_user
                         select User
                        );
            return query;
        }

        public dynamic Get_user_by_id(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbl_user> IRepositoryBase<tbl_user>.FindAll()
        {
            throw new NotImplementedException();
        }

        tbl_user IRepositoryBase<tbl_user>.FindByCompositeID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        tbl_user IRepositoryBase<tbl_user>.FindByCompositeID(int ID1, int ID2, int ID3)
        {
            throw new NotImplementedException();
        }

        tbl_user IRepositoryBase<tbl_user>.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        tbl_user IRepositoryBase<tbl_user>.FindByString(string ID)
        {
            throw new NotImplementedException();
        }
    }
}