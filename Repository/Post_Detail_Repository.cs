using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class Post_Detail_Repository : RepositoryBase<tbl_post_detail>, IPost_Detail_Repository
    {
        public dynamic Data_List = null;
        public Post_Detail_Repository(AppDb reposityContext)

        : base(reposityContext)
        {
        }

        public dynamic GetPostDetail()
        {
            var result = (from postdetail in RepositoryContext.tbl_post_detail

                          select postdetail
                            ).AsQueryable();
            Data_List = result.Select(s => s).ToList();
            return result;
        }
        public dynamic Data_To_List()
        {
            return Data_List;
        }
        public dynamic GetPostDetailByID(int id)
        {
            var result = (from postdetail in RepositoryContext.tbl_post_detail
                          where postdetail.post_detail_id == id
                          select postdetail
                            ).FirstOrDefault();
            return result;
        }

        public dynamic GetPostDetailByPostID(int id)
        {
            var result = (from postdetail in RepositoryContext.tbl_post_detail
                          where postdetail.post_id == id
                          select postdetail
                            ).ToList();
            return result;
        }
    }
}