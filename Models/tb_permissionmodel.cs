using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("tb_permission")]
    public class tb_permissionmodel : BaseModel
    {
        public int permission_id {get;set;}
        public string permission_name {get;set;}

    }
}