    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_permission_admin")]
    public class tbl_permission_admin : BaseModel
    {
        public int admin_id {get; set;}
        public int permission_id { get; set; }
        public int permission_admin_id{get; set;}

    }
}