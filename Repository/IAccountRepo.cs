namespace Ethereal_EM.Repository
{
    public interface IAccountRepo:IRepositoryBase<AccountModel>
    {
        dynamic GetAccount(int id);
        
    }
}