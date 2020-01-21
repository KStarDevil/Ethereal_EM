namespace Ethereal_EM.Repository
{
    public interface IPermission_Repository:IRepositoryBase<tbl_permission>
    {
        dynamic GetPermissionbyid(int Id);

        dynamic GetAllPermission();
    }
}