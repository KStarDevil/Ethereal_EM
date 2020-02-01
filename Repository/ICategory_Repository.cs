using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface ICategory_Repository:IRepositoryBase<tbl_category>
    {
        dynamic GetCategoryID(int id);
        dynamic GetCategory();
    }
}