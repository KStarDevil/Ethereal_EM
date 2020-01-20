using System;

namespace Ethereal_EM
{

    [System.ComponentModel.DataAnnotations.Schema.Table("hw_tb1_account")]
    public class hw_tb1_account : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        
    }
}