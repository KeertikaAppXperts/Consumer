using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerEntities
{
   public class InvoiceHeaderModel
    {
        public int InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public Nullable<int> CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> NetTotal { get; set; }
        public string Tax { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
