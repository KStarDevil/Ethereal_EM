namespace Ethereal_EM.Repository
{
    public interface Iposition_repo:IRepositoryBase<position_model>
    {
        dynamic GetPosition(int Id);
    }
}