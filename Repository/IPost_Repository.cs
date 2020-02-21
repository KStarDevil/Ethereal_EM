using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IPost_Repository:IRepositoryBase<tbl_post>
    {
        dynamic GetPostByID(int id);
        dynamic GetPost();
        dynamic Data_To_List();
    }
}