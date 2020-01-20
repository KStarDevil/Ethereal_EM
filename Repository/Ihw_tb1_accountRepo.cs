namespace Ethereal_EM.Repository
{
    public interface Ihw_tb1_accountRepo:IRepositoryBase<hw_tb1_account>
    {
        dynamic Getaccount(string name);
        
    }
}