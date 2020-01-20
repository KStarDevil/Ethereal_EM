using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Linq.Expressions;

namespace Ethereal_EM.Repository
{
    public class position_repo : RepositoryBase<position_repo>, Iposition_repo
    {
        public position_repo(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool AnyByCondition(Expression<Func<position_model, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<position_model> FindByCondition(Expression<Func<position_model, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public dynamic GetPermission(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic GetPosition(int Id)
        {
            // var main = (from v in RepositoryContext.position_model                            
            //                  where v.ID == Id select v).FirstOrDefault();
            //                  dynamic main1 = main as position_model; 

 var main = (from v in RepositoryContext.position_model                            
                             select new
                             {
                                 v.ID,
                                 v.Position
                             }
                             ).ToList();

            return main;
        }

        IEnumerable<position_model> IRepositoryBase<position_model>.FindAll()
        {
            throw new NotImplementedException();
        }

        position_model IRepositoryBase<position_model>.FindByCompositeID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        position_model IRepositoryBase<position_model>.FindByCompositeID(int ID1, int ID2, int ID3)
        {
            throw new NotImplementedException();
        }

        position_model IRepositoryBase<position_model>.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        position_model IRepositoryBase<position_model>.FindByString(string ID)
        {
            throw new NotImplementedException();
        }

      
    }
}