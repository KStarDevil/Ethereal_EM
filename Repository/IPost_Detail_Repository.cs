using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IPost_Detail_Repository:IRepositoryBase<tbl_post_detail>
    {
        dynamic GetPostDetailByID(int id);
        dynamic GetPostDetail();
    }
}