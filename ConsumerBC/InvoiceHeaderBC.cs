using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA=ConsumerDA;
using CA=ConsumerEntities;

namespace ConsumerBC
{
    public class InvoiceHeaderBC
    {
        DA::InvoiceHeaderDA invoiceHeaderDA = new DA.InvoiceHeaderDA();

        public List<CA::InvoiceHeaderModel> ShowAll_InvoiceHeaderBC()
        {
            return invoiceHeaderDA.ShowAll_Invoice();
        }
        public string SaveInvoiceBC(CA.InvoiceHeaderModel invoiceHeaderModel, List<CA.InvoiceDetailModel> invoiceDetailModels)
        {
            return invoiceHeaderDA.SaveInvoice(invoiceHeaderModel, invoiceDetailModels);
        }
        public string DeleteInvoiceBC(int invoiceNumber)
        {
            return invoiceHeaderDA.DeleteInvoice(invoiceNumber);
        }
        
        public CA.InvoiceHeaderModel EditInvoiceBC(int invoiceNumber)
        {
            return invoiceHeaderDA.EditInvoice(invoiceNumber);
        }
    }
}
