    using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_menu_permission")]
    public class tbl_menu_permission : BaseModel
    {
        public int menu_id {get; set;}
        public int permission_id { get; set; }
        public int menu_permission_id{get; set;}

    }
}