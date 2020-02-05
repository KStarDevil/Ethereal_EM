using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class User_Repository : RepositoryBase<tbl_user>, IUser_Repository
    {
        public User_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }
        public IEnumerable<tbl_user> FindByCondition(Expression<Func<tbl_user, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public dynamic Get_all_user()
        {
            var query = (from User in RepositoryContext.tbl_user
                         select User
                        ).ToList();
            return query;
        }

        public dynamic Get_user_by_id(int id)
        {
            var query = (from User in RepositoryContext.tbl_user
                        where User.user_id == id
                         select User 
                        ).FirstOrDefault();
            return query;
        }
    }
}