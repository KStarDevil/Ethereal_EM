//using Entities.ExtendedModels;
using System;
using System.Collections.Generic;

namespace Ethereal_EM.Repository
{
    public interface IEventLogRepository
    {
        IEnumerable<EventLog> GetEventLogByUser(int userID, string userType);
        void Insert(dynamic obj);
        void Update(dynamic obj);
        void Delete(dynamic obj);
        void InsertPriceChange(dynamic obj,string UserName,int UserID);
        void Info(string LogMessage);
        void Error(string LogMessage, string ErrMessage);
        void Warning(string LogMessage);
        dynamic getEventlogReportList(dynamic param);
    }
}
