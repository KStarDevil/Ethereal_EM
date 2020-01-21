namespace Ethereal_EM.Repository
{
    public interface IRole_Repository:IRepositoryBase<tbl_role>
    {
        dynamic GetRolebyid(int Id);

        dynamic GetAllRole();
    }
}