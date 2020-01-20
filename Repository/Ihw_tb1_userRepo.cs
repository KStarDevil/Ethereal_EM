namespace Ethereal_EM.Repository
{
    public interface Ihw_tb1_userRepo:IRepositoryBase<hw_tb1_user>
    {
        dynamic GetUser(int id);
        
    }
}