using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_saleinvoice")]
    public class SaleInvoice : BaseModel
    {
        public string saleinvoiceID { get; set; }
        public int customerID {get;set;}
        public DateTime invoiceDate { get; set; }
        public DateTime periodfrom { get; set; }
        public DateTime periodto { get; set; }
        public double totalamount { get; set; }
        public double discount { get; set; }
        public double netamount { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}