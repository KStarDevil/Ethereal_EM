using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface IBowserRepository:IRepositoryBase <Bowser>
    {
        int CheckDuplicateCarNo(int BowserID,string carno);
        int CheckDuplicatePhone (int BowserID,string Phone);
        dynamic GetAllBowserList(dynamic param);
        dynamic GetBowserData(int BowserID);
        dynamic GetAllBowserListMoblie();
        dynamic GetBowserCombo();
        dynamic GetBowserComboData(int DriverID);
    }
}