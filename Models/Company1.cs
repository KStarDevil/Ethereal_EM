using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("company")]
    public class Company1 : BaseModel
    {
        public int id {get;set;}
        public string C_Name {get;set;}
        public string C_Phone {get;set;}
        public string C_Address {get;set;}
        public string C_Description {get;set;}
    }
}