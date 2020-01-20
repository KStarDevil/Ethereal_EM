using System;

namespace Ethereal_EM
{
   [System.ComponentModel.DataAnnotations.Schema.Table("car")]


    public class carmodel : BaseModel
    {
        public int car_id { get; set; }
        public string car_name { get; set; }
        public DateTime car_produced { get; set; }
        public string car_model { get; set; }
        public Boolean gasoline { get; set; }
        public Boolean petrol { get; set; }
        public Double car_price{get; set;} 
        
    }
}