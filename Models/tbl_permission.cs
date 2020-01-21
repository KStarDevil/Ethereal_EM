    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_permission")]
    public class tbl_permission : BaseModel
    {
        public int permsiion_id {get; set;}
        public string permsiion_name { get; set; }

    }
}