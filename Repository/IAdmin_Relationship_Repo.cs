namespace Ethereal_EM.Repository
{
    public interface IAdmin_Relationship_Repo:IRepositoryBase<tb_relationmodel>
    {
        dynamic GetAdminPermission(int id);
        dynamic GetRelationshipById(int id);
        
    }
}