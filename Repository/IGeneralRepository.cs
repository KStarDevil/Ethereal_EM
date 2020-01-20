using Ethereal_EM;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IGeneralRepository : IRepositoryBase<General>
    {
        dynamic GetAllGeneral();
        General FindByid(int ID);
        dynamic GetGeneralTypes();
        dynamic GetTownshipCombo();
        dynamic GetDivisionCodeCombo();
        dynamic GetTownshipCodeCombo();
        dynamic GetCitizenCodeCombo();
        
        int CheckDuplicateGeneralName(int ID, string generalName);
     
        dynamic GetStateList();
        dynamic GetGeneralDescription(dynamic param);
        dynamic CustomerTypeList();

    }

}