using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IMenu_Repository:IRepositoryBase<tbl_menu>
    {
        List<tbl_menu> GetMenu();
        List<tbl_menu> Get_Menu_By_Amdin_ID(int ID);
    }
}