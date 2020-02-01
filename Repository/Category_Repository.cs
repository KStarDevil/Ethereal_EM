using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Category_Repository : RepositoryBase<tbl_category>, ICategory_Repository
    {
        public Category_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetCategory()
        {
            var result = (from category in RepositoryContext.tbl_category
                            
                            select category
                            ).ToList();
            return result;
        }

        public dynamic GetCategoryID(int id)
        {
            var result = (from category in RepositoryContext.tbl_category
                            where category.category_id == id
                            select category
                            ).FirstOrDefault();
            return result;
        }
    }
}