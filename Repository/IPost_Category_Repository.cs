using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IPost_Category_Repository:IRepositoryBase<tbl_post_category>
    {
        dynamic GetPostCategoryID(int id);
        dynamic GetPostCategory();
    }
}