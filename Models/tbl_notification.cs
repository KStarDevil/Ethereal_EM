using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_notification")]
    public class tbl_notification : BaseModel
    {
        public int notification_id {get; set;}
        public string notification_user_photo { get; set; }
        public int admin_id { get; set; }
        public string notification_title { get; set; }
        public string notification_description { get; set; }
        public int notification_status { get; set; }
        public DateTime notification_date { get; set; }
        public string notification_route { get; set; }
        public int post_id { get; set; }
               
    }
}