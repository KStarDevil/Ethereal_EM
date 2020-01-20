using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository

{
    public interface ITesting_Database:IRepositoryBase<Bun>
    {
      dynamic  GetItemData();
    }
}