//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumerEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceDetail
    {
        public int InvoiceNumber { get; set; }
        public int SIno { get; set; }
        public Nullable<int> ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> NetTotal { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
