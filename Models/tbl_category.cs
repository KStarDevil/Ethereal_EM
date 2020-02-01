using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_category")]
    public class tbl_category : BaseModel
    {
        public int category_id {get;set;}
        public int category_sub_id {get;set;}
        public string category_name {get;set;}

    }
}