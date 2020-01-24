namespace Ethereal_EM.Repository
{
    public interface INotification_Repository:IRepositoryBase<tbl_notification>
    {
        dynamic GetNotification();
    }
}