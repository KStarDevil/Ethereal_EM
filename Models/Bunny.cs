using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("roles")]
    public class Bun : BaseModel
    {
        public string name { get; set; }
        public string guard_name { get; set; }
        
        public int age { get; set; }
        public DateTime dob { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string DOB { get; set; }
        public string city { get; set; }
        

        public int id{get;set;}

    }
}