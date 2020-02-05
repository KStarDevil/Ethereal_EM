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

        public dynamic GetPostByCategoryID(int[] id, int filter_method, string search_text)
        {
            // filter_method 
            // 0 = Plain Text Search
            // 1 = Exact,
            // 2 = Include,
            // 3 = Except
            List<tbl_post_category> mini_result = new List<tbl_post_category>();
            dynamic result = null;
            List<tbl_post_category> before_data = new List<tbl_post_category>();
            List<tbl_post> after_data = new List<tbl_post>();
            if (filter_method == 1)
            {
                string category_string = string.Join(",", id);
                before_data = (from postcategory in RepositoryContext.tbl_post_category
                               where postcategory.category_id.Equals(category_string)
                               select postcategory
                            ).Distinct().ToList();
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
                before_data = mini_result.Distinct().ToList();
            }
            if (filter_method == 0)
            {

                result = (from post in RepositoryContext.tbl_post
                          where post.content_text.Contains(search_text)
                          select post).Distinct();
            }
            else
            {
                foreach (var item in before_data)
                {
                    var data = (from post in RepositoryContext.tbl_post
                                where post.post_id == item.post_id
                                select post).FirstOrDefault();
                    after_data.Add(data);
                }
                if (String.IsNullOrEmpty(search_text))
                {
                    result = (from post in after_data 
                              select post
                              ).AsQueryable();
                }
                else
                {
                    result = (from post in after_data
                              where post.content_text.Contains(search_text)
                              select post
                              ).Distinct().AsQueryable() ;
                }
            }   
            return result;
        }
    }
}