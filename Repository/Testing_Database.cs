using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class Testing_Database : RepositoryBase<Bun>, ITesting_Database
    {
        public Testing_Database(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetItemData()
        {
            var main = (from Bunn in RepositoryContext.Bun
                        select new
                        {
                            Bunn.name,
                            Bunn.guard_name
                        }
            ).ToList();
            return main;
        }
    }
}