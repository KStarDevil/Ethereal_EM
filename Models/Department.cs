using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("department")]
    public class Department : BaseModel
    {
        public int D_ID {get;set;}
        public string D_Name {get;set;}
        public string D_Location {get;set;}
        public string D_Description {get;set;}
        
    }
}