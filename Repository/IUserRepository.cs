namespace Ethereal_EM.Repository
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        dynamic GetUser(int id);
        
    }
}