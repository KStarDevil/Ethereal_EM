using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("users")]
    public class User : BaseModel
    {
        public int id {get;set;}
        public string name {get;set;}
        public string address {get;set;}
        public string phone {get;set;}
        public string email {get;set;}
    }
}