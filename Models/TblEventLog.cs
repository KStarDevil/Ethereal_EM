using System;

namespace Ethereal_EM
{
     [System.ComponentModel.DataAnnotations.Schema.Table("tbl_eventlog")]
    public class EventLog: BaseModel
    {
        public int ID { get; set; }
        public EventLogType LogType { get; set; }
        public DateTime LogDateTime { get; set; }
        public string Source { get; set; } // api or web or mobile
        public string FormName {get;set;}  // controller.function name
        public string LogMessage { get; set; }
        public string ErrMessage {get;set;}
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string ipAddress { get; set; }
    }

    public enum EventLogType
    {
        Info = 1,
        Error = 2,
        Warning = 3,
        Insert = 4,
        Update = 5,
        Delete = 6
    }
}