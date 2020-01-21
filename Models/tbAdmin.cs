using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_admin")]
    public class tbAdmin : BaseModel
    {
        public int admin_id {get; set;}
        public string admin_name { get; set; }
        public string admin_password { get; set; }       
        public string admin_photo { get; set; }

    }
}