    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_permission_role")]
    public class tbl_permission_role : BaseModel
    {
        public int role_id {get; set;}
        public int permission_id { get; set; }
        public int permission_role_id{get; set;}

    }
}