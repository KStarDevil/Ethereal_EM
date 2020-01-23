namespace Ethereal_EM.Repository
{
    public interface IRole_Admin_Repository:IRepositoryBase<tbl_role_admin>
    {
        dynamic GetRoleAdmin();
    }
}