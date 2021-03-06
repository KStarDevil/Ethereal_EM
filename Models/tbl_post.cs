    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_post")]
    public class tbl_post : BaseModel
    {
        public int post_id {get; set;}
        public string user_photo { get; set; }
        public int uploader_id {get; set;}
        public string content_text { get; set; }
        public int photo_count { get; set; }
        public DateTime created_date { get; set; }
        public int status {get; set;}
        public DateTime approved_rejected_date { get; set; }

    }
}