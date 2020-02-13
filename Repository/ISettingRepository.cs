//using Entities.ExtendedModels;
using Ethereal_EM;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        IEnumerable<Setting> GetPasswordValidation();
        IEnumerable<Setting> GetAllowLoginFailCount();
        IEnumerable<Setting> GetEmailSetting();
        IEnumerable<Setting> Get_Mail_Settings();
       Setting FindById(int ID);
        dynamic GetSettingData();

    }

}
