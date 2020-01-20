namespace Ethereal_EM.Repository
{
    public interface IDepartmentrepo:IRepositoryBase<Department>
    {
        dynamic GetDepartment();
    }
}