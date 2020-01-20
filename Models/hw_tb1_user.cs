using System;

namespace Ethereal_EM
{

    [System.ComponentModel.DataAnnotations.Schema.Table("hw_tb1_user")]
    public class hw_tb1_user : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        
    }
}