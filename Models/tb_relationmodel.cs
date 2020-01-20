using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tb_relation")]
    public class tb_relationmodel : BaseModel
    {
        public int relation_id {get;set;}
        public int admin_id {get;set;}
        public int permission_id {get;set;}
        

    }
}