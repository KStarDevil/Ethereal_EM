namespace Ethereal_EM.Repository
{
    public interface IAdmin_Admin_Repo:IRepositoryBase<tb_adminmodel>
    {
        dynamic GetAdminPermission(int id);
        dynamic GetAdminById(int id);
    }
}