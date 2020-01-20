using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tb_admin")]
    public class tb_adminmodel : BaseModel
    {
        public int admin_id {get;set;}
        public string admin_name {get;set;}

    }
}