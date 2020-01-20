using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("account")]
    public class AccountModel : BaseModel
    {
        public int A_ID {get; set;}
        public string A_Name { get; set; }
        public string A_Password { get; set; }       
        public string A_Device { get; set; }
        public string A_NRC { get; set; }
        public string A_Phone { get; set; }

    }
}