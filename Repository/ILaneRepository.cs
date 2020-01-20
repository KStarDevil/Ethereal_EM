using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface ILaneRepository :IRepositoryBase<Lane>
    {
        dynamic GetLaneDataList (dynamic param);

        dynamic GetPetrolList();

        dynamic GetLaneEditData(int ID);
      dynamic  CheckDuplicate(int LaneID, string name);
    }
}