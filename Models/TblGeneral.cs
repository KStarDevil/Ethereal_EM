using System;

namespace Ethereal_EM
{
     [System.ComponentModel.DataAnnotations.Schema.Table("tbl_general")]
    public class General: BaseModel
    {
        public int id { get; set; }
         public int? stateid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool isactive { get; set; }
    }
    
}