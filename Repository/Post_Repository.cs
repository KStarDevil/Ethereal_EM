using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Post_Repository : RepositoryBase<tbl_post>, IPost_Repository
    {
        public dynamic Data_List = null;
        public Post_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetPost()
        {
            var result = (from post in RepositoryContext.tbl_post

                          select post
                            ).AsQueryable();
            Data_List = result.Select(s => s).ToList();
            return result;
        }
        public dynamic Data_To_List()
        {
            return Data_List;
        }

        public dynamic GetPostByID(int id)
        {
            var result = (from post in RepositoryContext.tbl_post
                          where post.post_id == id
                          select post
                            ).FirstOrDefault();
            return result;
        }
    }
}