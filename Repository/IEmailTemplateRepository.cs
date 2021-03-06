//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IEmailTemplateRepository
    {
        IEnumerable<EmailTemplate> GetEmailTemplate(string templateName);
        dynamic GetSettingResult();
    }
}
