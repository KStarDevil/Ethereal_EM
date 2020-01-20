using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class GeneralRepository : RepositoryBase<General>, IGeneralRepository
    {
        public GeneralRepository(AppDb repositoryContext) : base(repositoryContext)
        {
            //this.RepositoryContext = repositoryContext;
        }

        public dynamic GetAllGeneral()
        {
            var mainQuery = from main in RepositoryContext.General
                            select new { main.type };
            return mainQuery;
        }


        public General FindByid(int id)
        {
            return FindByID(id);
            /* 
            var obj = RepositoryContext.General.Find(id);
            if (obj != null)
            {
                obj.CopyOldObj();
            }
            return obj;*/
        }
        public dynamic GetGeneralTypes()


        {


            var mainQuery = from main in RepositoryContext.General
                            where main.isactive == true
                            select new
                            {
                                main.id,
                                main.stateid,
                                main.name,
                                main.type,
                                main.isactive
                            };
            return mainQuery;
        }

        public int CheckDuplicateGeneralName(int ID, string generalName)
        {
            return FindByCondition(x => x.id != ID && x.name == generalName).Count();
        }

        public dynamic GetTownshipCombo()
        {
            var mainQuery = from main in RepositoryContext.General
                            where main.type == "Township"
                            select new
                            {
                                Townshipname = main.name,
                                Township = main.id
                            };
            return mainQuery;
        }


        public dynamic GetStateList()
        {
            var query = (from ge in RepositoryContext.General
                         where ge.isactive == true && ge.type == "State"
                         select new
                         {
                             name = ge.name,
                             stateid = ge.id
                         });
            return query;
        }

        public dynamic GetGeneralDescription(dynamic param)
        {
            dynamic obj = param;
            string type = obj;

            var query = (from main in RepositoryContext.General
                         where main.isactive == true && main.type == type
                         select new
                         {
                             id = main.id,
                             name = main.name
                         }).ToList();

            return query;
        }

        public dynamic CustomerTypeList()
        {
            var query = (from ge in RepositoryContext.General
                         where ge.isactive == true && ge.type == "Customer Group"
                         select new
                         {
                             CustomerTypeID = ge.id,
                             CustomerTypeName = ge.name
                         });
            return query;
        }

        public dynamic GetDivisionCodeCombo()
        {
            var query = (from ge in RepositoryContext.General
                         where ge.isactive == true && ge.type == "NRC Division Code"
                         select new
                         {
                             name = ge.name,
                             divisionid = ge.id
                         });
            return query;
        }

        public dynamic GetTownshipCodeCombo()
        {
            var query = (from ge in RepositoryContext.General
                         where ge.isactive == true && ge.type == "NRC Township Code"
                         select new
                         {
                             name = ge.name,
                             townshipid = ge.id
                         });
            return query;
        }

        public dynamic GetCitizenCodeCombo()
        {
            var query = (from ge in RepositoryContext.General
                         where ge.isactive == true && ge.type == "NRC Citizen Code"
                         select new
                         {
                             name = ge.name,
                             citizenid = ge.id
                         });
            return query;
        }
    }


}
