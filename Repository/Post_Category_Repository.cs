using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

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

        public dynamic GetPostByPostID(int id)
        {
            var result = (from postcategory in RepositoryContext.tbl_post_category
                          where postcategory.post_id == id
                          select postcategory
                            ).FirstOrDefault();
            return result;
        }

        public dynamic GetPostByCategoryID(int[] id, int filter_method)
        {
            // filter_method 
            // 1 = Exact,
            // 2 = Include,
            // 3 = Except
            List<dynamic> mini_result = new List<dynamic>();
            dynamic result = null;
            if (filter_method == 1)
            {
                string category_string = string.Join(",", id);
                result = (from postcategory in RepositoryContext.tbl_post_category
                          where postcategory.category_id.Equals(category_string)
                          select postcategory
                            ).ToList();
            }
            else if (filter_method == 2)
            {
                foreach (var item in id)
                {
                    var cat = (from postcategory in RepositoryContext.tbl_post_category
                               where postcategory.category_id.Contains(item.ToString())
                               select postcategory
                                       ).ToList();
                    foreach (var item1 in cat)
                    {
                        mini_result.Add(item1);
                    }
                }
                result = mini_result.Distinct().ToList();
            }

            return result;
        }
    }
}