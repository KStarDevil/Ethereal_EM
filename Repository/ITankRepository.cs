using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ITankRepository:IRepositoryBase<Tank>
    {
        dynamic GetTankDataList(dynamic param);
         dynamic GetListPetrol ();
         dynamic GetTankUpdate( int tankID);
         dynamic GetTankCombo();
         dynamic GetProductName(int TankID);
    }
}