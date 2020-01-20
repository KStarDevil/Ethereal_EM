using System;

namespace Ethereal_EM
{
     [System.ComponentModel.DataAnnotations.Schema.Table("tbl_product")]
    public class Product: BaseModel
    {
        public int productID { get; set; }
       
        public string productName { get; set; }
       
        public bool inactive { get; set; }

        public DateTime modifieddate {get;set;}

    }
    
}