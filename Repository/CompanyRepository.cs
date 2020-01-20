using System.Linq;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace Ethereal_EM.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public int CheckDuplicateCode(int CompanyID, string code)
        {
            return FindByCondition(x => x.companyID != CompanyID && x.code == code && x.inactive==true).Count();
        }

        public int CheckDuplicateName(int CompanyID, string CompanyName)
        {
            return FindByCondition(x => x.companyID != CompanyID && x.name == CompanyName && x.inactive==true).Count();
        }

        public int CheckDuplicatePhone(int CompanyID, string Phone)
        {
            return FindByCondition(x => x.companyID != CompanyID && x.phone == Phone && x.inactive==true).Count();
        }

        public dynamic GetAllCompany(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);


            var MainQuery = (from main in RepositoryContext.Company
                             where main.inactive == true
                             select new
                             {
                                 CompanyID = main.companyID,
                                 CompanyName = main.name,
                                 Address = main.address,
                                 Phone = main.phone,
                                 Code = main.code,
                                 Township = (from general in RepositoryContext.General where main.township == general.id select general.name).FirstOrDefault(),
                                 State = (from general in RepositoryContext.General where main.state == general.id select general.name).FirstOrDefault(),

                             });
            return MainQuery.ToDataSourceResult(request);
        }

        public dynamic GetCompanyList(int CompanyID)
        {
            dynamic objresponse = null;


            var mainQuery = (from main in RepositoryContext.Company
                             where main.companyID == CompanyID
                             select new
                             {
                                 CompanyID = main.companyID,
                                 CompanyName = main.name,
                                 Address = main.address,
                                 Phone = main.phone,
                                 Code = main.code,
                                 Townshipid = main.township,
                                 Stateid = main.state,

                             }).ToList();

            objresponse = new { data = mainQuery };

            return objresponse;
        }

        public dynamic GetStateListForCompany()
        {
            var mainQuery = (from main in RepositoryContext.General
                             where main.isactive == true && main.type == "State"
                             select new
                             {

                                 Stateid = main.id,
                                 State = main.name,

                             });
            var aa = mainQuery.ToList();
            return mainQuery;
        }

        public dynamic GetTownshipList(int stateID)
        {
            var mainQuery = (from main in RepositoryContext.General
                             where main.stateid == stateID && main.isactive == true && main.type=="Township"
                             select new
                             {

                                 Township = main.id,
                                 Townshipname = main.name,

                             });
            var aa = mainQuery.ToList();
            return mainQuery;
        }


    }
}