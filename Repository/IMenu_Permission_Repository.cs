namespace Ethereal_EM.Repository
{
    public interface IMenu_Permission_Repository:IRepositoryBase<tbl_menu_permission>
    {
        dynamic GetMenuPermission();
        dynamic GetMenuPermissionById(int id);
    }
}