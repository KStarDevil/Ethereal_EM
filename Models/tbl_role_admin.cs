    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_role_admin")]
    public class tbl_role_admin : BaseModel
    {
        public int admin_id {get; set;}
        public int role_id { get; set; }

    }
}