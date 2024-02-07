using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerEntities
{
    public class InvoiceDetailModel
    {
        public int InvoiceNumber { get; set; }
        public int SIno { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal NetTotal { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }

        public virtual InvoiceHeader InvoiceHeader { get; set; }
    }
}
