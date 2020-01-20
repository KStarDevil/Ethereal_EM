namespace Ethereal_EM.Repository
{
    public interface IAdmin_Permission_Repo:IRepositoryBase<tb_permissionmodel>
    {
        dynamic GetAdminPermission(int id);
        dynamic GetPermissionById(int id);
    }
}