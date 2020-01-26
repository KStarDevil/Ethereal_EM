    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_post_detail")]
    public class tbl_post_detail : BaseModel
    {
        public int post_detail_id {get; set;}
        public int post_id {get; set;}
        public string content_text { get; set; }
        public string photo { get; set; }

    }
}