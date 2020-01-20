using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class EmailTemplateRepository : RepositoryBase<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<EmailTemplate> GetEmailTemplate(string templateName) {
            return FindByCondition(x => x.template_name == templateName);
        }

        public dynamic GetSettingResult()
        {
            var settingresult = (
                                   from setting in RepositoryContext.Setting
                                   where setting.Name == "SMTP" || setting.Name == "Email"
                                   || setting.Name == "Email Password" || setting.Name == "Server Port"
                                   orderby setting.SettingID
                                   select setting).ToList();
            return settingresult;
        }
    }
}
