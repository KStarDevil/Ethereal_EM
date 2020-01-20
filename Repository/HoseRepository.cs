using System.Collections.Generic;
using System.Linq;
using System;
using Repository;

namespace Ethereal_EM.Repository
{
    public class HoseRepository : RepositoryBase<Hose>, IHoseRepository
    {
        public HoseRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetItemData(int ID)
        {
            var main = (from hose in RepositoryContext.Hose
                        where hose.inactive == true && hose.laneID == ID
                        select new
                        {
                            hose.hoseID,
                            hose.laneID,
                            hose.hoseNumber,
                            hose.inactive
                        }
            ).ToList();
            return main;
        }
    }
}