using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_menu")]
    public class tbl_menu : BaseModel
    {
        public int menu_id {get; set;}
        public int sub_menu_id { get; set; }
        public string menu_name { get; set; }       
        public string menu_route { get; set; }

    }
}