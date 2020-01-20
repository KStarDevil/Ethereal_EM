using System;
using System.Collections.Generic;
using Ethereal_EM; 

namespace Ethereal_EM.Repository
{
    public interface IDriverRepository: IRepositoryBase<Driver>
    {
        int CheckDuplicateCard(int DriverID, string cardno);
        int CheckDuplicateNRC(int DriverID, int nrc);
        int CheckDuplicateLicense(int DriverID, string License);
        int CheckDuplicatePhone(int DriverID, string Phone);
        dynamic GetAllDriverList(dynamic param);
        dynamic GetDriverData(int DriverID);
        dynamic GetDriverCombo();
        dynamic GetAllMobileDriverList();
        dynamic GetDriverName(string Name);
    }
}