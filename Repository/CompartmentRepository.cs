using System;
using System.Collections.Generic;
using Ethereal_EM;
using Repository;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class CompartmentRepository : RepositoryBase<Compartment>, ICompartmentRepository
    {
        public CompartmentRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic GetCompartment(int BowserID)
        {
            var mainQuery = (from c in RepositoryContext.Compartment
                             where c.bowserID == BowserID
                             select new
                             {
                                 Compartment = c.name,
                                 CompartmentId = c.compartmentID,
                                 id =0,
                                 Liter=0
                             });
            return mainQuery;
        }
    }
}