namespace Ethereal_EM.Repository
{
    public interface IPermission_Admin_Repository:IRepositoryBase<tbl_permission_admin>
    {
        dynamic GetPermissionAdmin();
    }
}