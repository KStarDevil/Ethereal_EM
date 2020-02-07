using System.Collections.Generic;
using System.Linq;
using System;
using Repository;
using Microsoft.AspNetCore.Http;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Ethereal_EM.Repository
{
    public class EventLogRepository : RepositoryBase<EventLog>, IEventLogRepository
    {
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public EventLogRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
            _httpContextAccessor = CustomTokenAuthProvider.TokenProviderMiddleware._httpContextAccessor;
        }
        public IEnumerable<EventLog> GetEventLogByUser(int userID, string userType)
        {
            return FindByCondition(x => x.UserID == userID && x.UserType == userType);
        }

        public void AddEventLog(EventLogType LogTypeEnum, string LogMessage, string ErrMessage)
        {
            EventLogType LogType = LogTypeEnum;
            string LoginUserID = _session.GetString("LoginUserID");
            string LoginRemoteIpAddress = _session.GetString("LoginRemoteIpAddress");
            string LoginTypeParam = _session.GetString("LoginTypeParam");
            string Source = _session.GetString("ApiSource");
            string FormName = _session.GetString("ControllerAction");
            if (LogMessage != "" || ErrMessage != "")
            {
                if (LoginTypeParam == "" || LoginTypeParam == null) LoginTypeParam = "0";
                string LoginTypestr = "public";
                int LoginType = 0;
                if (LoginTypeParam == "mobile")
                {
                    LoginType = 2;
                }
                else
                {
                    LoginType = int.Parse(LoginTypeParam);
                }

                if (LoginType == 1)
                    LoginTypestr = "admin";
                else if (LoginType == 2)
                    LoginTypestr = "Mobile_Customer";
                try
                {
                    var newobj = new EventLog();
                    newobj.LogType = LogType;
                    newobj.LogDateTime = DateTime.Now;
                    newobj.Source = Source;
                    newobj.FormName = FormName;
                    newobj.LogMessage = LogMessage;
                    newobj.ErrMessage = ErrMessage;
                    newobj.UserID = int.Parse(LoginUserID);
                    newobj.UserType = LoginTypestr;
                    newobj.ipAddress = LoginRemoteIpAddress;

                    Create(newobj);
                    Save();

                }
                catch (Exception ex)
                {
                    Globalfunction.WriteSystemLog("SQL Exception :" + ex.Message);
                }
            }
        }
        public void AddEventLog1(EventLogType LogTypeEnum, string LogMessage, string ErrMessage, string UserName, int UserID)
        {
            EventLogType LogType = LogTypeEnum;
            string LoginRemoteIpAddress = _session.GetString("LoginRemoteIpAddress");
            string LoginTypeParam = _session.GetString("LoginTypeParam");
            string Source = _session.GetString("ApiSource");
            string FormName = _session.GetString("ControllerAction");
            if (LogMessage != "" || ErrMessage != "")
            {
                try
                {
                    var newobj = new EventLog();
                    newobj.LogType = LogType;
                    newobj.LogDateTime = DateTime.Now;
                    newobj.Source = Source;
                    newobj.FormName = FormName;
                    newobj.LogMessage = LogMessage;
                    newobj.ErrMessage = ErrMessage;
                    newobj.UserID = UserID;
                    newobj.UserType = UserName;
                    newobj.ipAddress = LoginRemoteIpAddress;

                    Create(newobj);
                    Save();

                }
                catch (Exception ex)
                {
                    Globalfunction.WriteSystemLog("SQL Exception :" + ex.Message);
                }
            }
        }

        public void Insert(dynamic obj)
        {
            string LogMessage = "";
            LogMessage += "Created new data are as follow:\r\n";
            LogMessage += obj.GetEventLogMessage();

            AddEventLog(EventLogType.Insert, LogMessage, "");
        }

        public void Update(dynamic obj)
        {
            string LogMessage = "";
            LogMessage += "Updated data are as follow:\r\n";
            LogMessage += obj.GetEventLogMessage();
            AddEventLog(EventLogType.Update, LogMessage, "");
        }

        public void Delete(dynamic obj)
        {
            string LogMessage = "";
            LogMessage += "Deleted old data are as follow:\r\n";
            LogMessage += obj.GetEventLogMessage();
            AddEventLog(EventLogType.Delete, LogMessage, "");
        }

        public void Error(string LogMessage, string ErrMessage)
        {
            AddEventLog(EventLogType.Error, LogMessage, ErrMessage);
        }

        public void Info(string LogMessage)
        {
            AddEventLog(EventLogType.Info, LogMessage, "");
        }

        public void Warning(string LogMessage)
        {
            AddEventLog(EventLogType.Warning, LogMessage, "");
        }
        public void Error(string Source, string Form, string LogMessage, string ErrMessage)
        {
            int ActionID = Convert.ToInt32(null);
            AddEventLog(EventLogType.Error, LogMessage,"");
        }
        public dynamic getEventlogReportList(dynamic param)
        {
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            dynamic obj = param;
            var mainQuery = from ev in RepositoryContext.EventLog
                            join ad in RepositoryContext.Admin on ev.UserID equals ad.AdminID into tmp
                            from c in tmp.DefaultIfEmpty()
                            select new
                            {
                                ev.ID,
                                LogDateTime = ev.LogDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                Message = (ev.LogType.ToString() == "2" ? ev.ErrMessage : ev.LogMessage),
                                LogType = Enum.GetName(typeof(EventLogType), ev.LogType),
                                Source = ev.Source,
                                UserType = ev.UserType,
                                ev.ipAddress,
                                Name = c.AdminName,
                                FormName = ev.FormName

                            };

            if (obj.data.FromDate.ToString() != "")
            {
                DateTime fromDate = obj.data.FromDate + " 00:00:00";
                mainQuery = mainQuery.Where(m => Convert.ToDateTime(m.LogDateTime) >= fromDate);
            }
            if (obj.data.ToDate.ToString() != "")
            {
                DateTime toDate = obj.data.ToDate + " 23:59:59";
                mainQuery = mainQuery.Where(m => Convert.ToDateTime(m.LogDateTime) <= toDate);
            }
            if (obj.data.logtype.ToString() != "")
            {
                String logtype = Convert.ToString(obj.data.logtype.Value);
                mainQuery = mainQuery.Where(m => m.LogType == logtype);
            }
            return mainQuery.ToDataSourceResult(request);
        }

        public void InsertPriceChange(dynamic obj, string UserName, int UserID)
        {
            string LogMessage = "";
            LogMessage += "Change the price of" + obj.Name + " from " + obj.oldPrice.ToString() + " To " + obj.Price;

            AddEventLog1(EventLogType.Insert, LogMessage, "", UserName, UserID);
        }
    }
}
