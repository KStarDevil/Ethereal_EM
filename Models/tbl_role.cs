    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_role")]
    public class tbl_role : BaseModel
    {
        public int role_id {get; set;}
        public string role_name { get; set; }

    }
}