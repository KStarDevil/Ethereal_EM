using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_saleinvoiceitem")]
    public class SaleInvoiceItem : BaseModel
    {
        public string saleinvoiceitemID { get; set; }
        public string saleinvoiceID { get; set; }
        public int product { get; set; }
        public double balanceliter { get; set; }
        public double chargesrate { get; set; }
        public double amount { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}