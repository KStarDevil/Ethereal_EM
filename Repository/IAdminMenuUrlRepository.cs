//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IAdminMenuUrlRepository
    {
        AdminMenuUrl GetAdminMenuUrlById(int AdminMenuUrlId);
        AdminMenuUrl GetAdminMenuUrlByServiceUrl(string ServiceUrl);
        void UpdateAdminMenuUrl(AdminMenuUrl AdminMenuUrl);
    }
}
