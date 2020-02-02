using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IPost_Category_Repository:IRepositoryBase<tbl_post_category>
    {
        dynamic GetPostByCategoryID(int[] id, int filter_method, string search_text);
        dynamic GetPostByPostID (int id);
        dynamic GetPostCategory();
    }
}