using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Post_Category_Repository : RepositoryBase<tbl_post_category>, IPost_Category_Repository
    {
        public Post_Category_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetPostCategory()
        {
            var result = (from postcategory in RepositoryContext.tbl_post_category
                            
                            select postcategory
                            ).ToList();
            return result;
        }

        public dynamic GetPostCategoryID(int id)
        {
            var result = (from postcategory in RepositoryContext.tbl_post_category
                            where postcategory.post_category_id == id
                            select postcategory
                            ).FirstOrDefault();
            return result;
        }
    }
}