using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IMenu_Repository:IRepositoryBase<tbl_menu>
    {
        List<tbl_menu> GetMenu();
    }
}