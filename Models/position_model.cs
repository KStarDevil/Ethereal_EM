using System;
namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("testing_position")]
    public class position_model : BaseModel
    {
        public int ID { get; set; }
        public string Position { get; set; }
    }
}