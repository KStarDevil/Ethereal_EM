using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tbl_post_category")]
    public class tbl_post_category : BaseModel
    {
        public int post_category_id {get;set;}
        public int category_id {get;set;}
        public int post_id {get;set;}

    }
}