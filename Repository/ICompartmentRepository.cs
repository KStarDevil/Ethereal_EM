using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ICompartmentRepository: IRepositoryBase<Compartment>
    {
        dynamic GetCompartment(int BowserID);
    }
}