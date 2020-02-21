using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_user_notification")]
    public class tbl_user_notification : BaseModel
    {
        public int user_notification_id {get; set;}
        public int user_id { get; set; }
        public string notification_id { get; set; }       
    }
}