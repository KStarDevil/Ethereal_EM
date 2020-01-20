using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository

{
    public interface IHoseRepository:IRepositoryBase<Hose>
    {
      dynamic  GetItemData( int ID);
    }
}