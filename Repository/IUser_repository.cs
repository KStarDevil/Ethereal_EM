namespace Ethereal_EM.Repository
{
    public interface IUser_Repository:IRepositoryBase<tbl_user>
    {
        dynamic Get_user_by_id(int id);
        dynamic Get_all_user();
    }
}