namespace Ethereal_EM.Repository
{
    public interface IPermission_Role_Repository:IRepositoryBase<tbl_permission_role>
    {
        dynamic Get_Permission_By_Role(int Id); 
    }
}