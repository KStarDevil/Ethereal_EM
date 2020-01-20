using Ethereal_EM;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface ICompanyRepository: IRepositoryBase<Company>
    {

        
        dynamic GetAllCompany(dynamic param);

        dynamic GetCompanyList ( int CompanyID );
        dynamic GetTownshipList(int stateID);
       dynamic  GetStateListForCompany();
       int CheckDuplicateCode(int CompanyID,string code);
       int CheckDuplicateName(int CompanyID,string CompanyName);
       int CheckDuplicatePhone(int CompanyID,string Phone);

        
    }
}