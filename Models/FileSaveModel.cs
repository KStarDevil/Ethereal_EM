using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("savingfile")]
    public class FileSaveModel : BaseModel
    {
        public int id {get; set;}
        public string file{get;set;}
        
    }
}