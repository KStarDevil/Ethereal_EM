namespace Ethereal_EM.Repository
{
    public interface IMenu_Repository:IRepositoryBase<tbl_menu>
    {
        dynamic GetMenu();
    }
}