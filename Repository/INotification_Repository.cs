namespace Ethereal_EM.Repository
{
    public interface INotification_Repository:IRepositoryBase<tbl_notification>
    {
        dynamic GetNotification();
        dynamic GetPermissionById(int id);
        dynamic Get_Notification_By_CategoryID_UserID(int[] id, int user_id);
    }
}