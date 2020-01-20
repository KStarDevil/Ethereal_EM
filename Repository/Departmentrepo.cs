using System.Linq;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace Ethereal_EM.Repository
{
    public class Departmentrepo : RepositoryBase<Department>, IDepartmentrepo
    {
        public Departmentrepo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetDepartment(int Id)
        {
            throw new System.NotImplementedException();
        }

        

        public dynamic GetDepartment()
        {
           var all = (from v in RepositoryContext.Department                            
                             select new
                             {
                                 v.D_ID,
                                 v.D_Name,
                                 v.D_Location,
                                 v.D_Description
                             }
                             ).ToList();

            return all;
        }
        

        


    }
}