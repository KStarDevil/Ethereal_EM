using System;

namespace Ethereal_EM
{

    [System.ComponentModel.DataAnnotations.Schema.Table("hw_tb1_register")]
    public class hw_tb1_register : BaseModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public string info { get; set; }
        
    }
}