using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_user")]
    public class tbl_user : BaseModel
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_phone { get; set; }
        public string user_location { get; set; }
        public DateTime user_registered_date { get; set; }
        public string user_email { get; set; }
    }
}