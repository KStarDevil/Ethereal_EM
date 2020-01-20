namespace Ethereal_EM.Repository
{
    public interface Ihw_tb1_registerRepo:IRepositoryBase<hw_tb1_register>
    {
        dynamic Getregister(string password);
        
    }
}