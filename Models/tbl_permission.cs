    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_permission")]
    public class tbl_permission : BaseModel
    {
        public int permission_id {get; set;}
        public string permission_name { get; set; }

    }
}