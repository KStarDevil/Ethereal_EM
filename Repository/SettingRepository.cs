using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(AppDb repositoryContext) : base(repositoryContext)
        {

        }
        public IEnumerable<Setting> GetPasswordValidation()
        {
            return FindByCondition(x => x.Name == "Password Validation");
        }

        public IEnumerable<Setting> GetAllowLoginFailCount()
        {
            return FindByCondition(x => x.Name == "Allow Login Failure Count");
        }

        public IEnumerable<Setting> GetEmailSetting()
        {
            return FindByCondition(x => x.Name == "SMTP" || x.Name == "Email"
                                    || x.Name == "Email Password" || x.Name == "Server Port")
                                .OrderBy(x => x.SettingID);

        }
         public IEnumerable<Setting> Get_Mail_Settings()
        {
            return FindByCondition(x => x.Name == "SMTP" || x.Name == "Email"
                                    || x.Name == "Email_Password" || x.Name == "Server_Port" || x.Name=="Email_Name")
                                .OrderBy(x => x.SettingID);

        }

        public dynamic GetSettingData()
        {
            var mainQuery = from setting in RepositoryContext.Setting
                            select new
                            {
                               SettingID=setting.SettingID,
                               Name=setting.Name,
                               Value=setting.Value
                            };
            return mainQuery;
        }

        public Setting FindById(int ID)
        {
            return FindByID(ID);
            /*var obj = RepositoryContext.Setting.Find(ID);
            if (obj != null)
            {
                obj.CopyOldObj();
            }
            return obj;*/
        }
    }
}
