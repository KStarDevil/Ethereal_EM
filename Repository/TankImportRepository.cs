using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class TankImportRepository: RepositoryBase<TankImport>, ITankImportRepository
    {
        public TankImportRepository(AppDb repositoryContext)
            :base(repositoryContext)
        {
        }

    }
}