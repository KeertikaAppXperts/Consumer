using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA = ConsumerEntities;

namespace ConsumerDA
{
    public class InvoiceHeaderDA
    {
        CA::CustomerEntities customerEntities = new CA::CustomerEntities();

        public List<CA::InvoiceHeaderModel> ShowAll_Invoice()
        {
            List<CA::InvoiceHeaderModel> invoiceHeaderModels = new List<CA.InvoiceHeaderModel>();
            var datalist = customerEntities.InvoiceHeaders.ToList();
            if(datalist!=null & datalist.Count>0)
            {
                datalist.ForEach(item =>
                {
                    invoiceHeaderModels.Add(new CA.InvoiceHeaderModel
                    {
                        InvoiceNumber = item.InvoiceNumber,
                        InvoiceDate = item.InvoiceDate,
                        CustomerCode = item.CustomerCode,
                        CustomerName = item.CustomerName,
                        NetTotal = item.NetTotal

                    });
                }) ;
            }
            return invoiceHeaderModels;
        }
        public string SaveInvoice(CA.InvoiceHeaderModel objHeaderItems, List<CA.InvoiceDetailModel> invoiceDetailModels)
        {
            string result = string.Empty;
            //bool headerSave = false;
            //CA.InvoiceDetail _Details = new CA.InvoiceDetail();
            int i = 1;
            try
            {
                if (objHeaderItems != null & invoiceDetailModels != null)
                {
                   
                    CA.InvoiceHeader obj = new CA.InvoiceHeader()
                    {
                        //InvoiceNumber = objHeaderItems.InvoiceNumber,
                        InvoiceDate = DateTime.Now,
                        CustomerCode = objHeaderItems.CustomerCode,
                        CustomerName = objHeaderItems.CustomerName,
                        Address = objHeaderItems.Address,
                        City = objHeaderItems.City,
                        Tax = objHeaderItems.Tax,
                        CreatedBy = "keertika",
                        CreatedOn = DateTime.Now,
                        SubTotal = (decimal)objHeaderItems.SubTotal,
                        NetTotal = (decimal)objHeaderItems.NetTotal,
                    };
                  
                    
                       
                        customerEntities.InvoiceHeaders.Add(obj);
                        customerEntities.SaveChanges();
                    int no = obj.InvoiceNumber;
                    // headerSave = true;
                    //if (headerSave)
                    

                        invoiceDetailModels.ForEach(item =>
                            {
                                
                                CA.InvoiceDetail _details = new CA.InvoiceDetail
                                {
                                   
                                    InvoiceNumber = no,
                                    SIno=i,
                                    ProductCode = item.ProductCode,
                                    ProductName = item.ProductName,
                                    Price = item.Price,
                                    Tax = item.Tax,
                                    Quantity = item.Quantity,
                                    Total = item.Total,
                                    CreatedBy = "keertika",
                                    CreatedOn = DateTime.Now,
                                    SubTotal = (decimal)item.SubTotal,
                                    NetTotal = (decimal)item.NetTotal,

                                };
                                i = i + 1;
                                customerEntities.InvoiceDetails.Add(_details);
                                customerEntities.SaveChanges();

                                
                            });
                    result = "success";
                }


            }
            catch (Exception ex)
            {
            
            }
            return result;
        }
        public string DeleteInvoice(int invoiceNumber)
        {
            string result = string.Empty;
            var data_headers = customerEntities.InvoiceHeaders.Where(y => y.InvoiceNumber == invoiceNumber).FirstOrDefault();
           // var data_details = customerEntities.InvoiceDetails.Where(y => y.InvoiceNumber == invoiceNumber).FirstOrDefault();
          //  if (data_headers !=null & data_details!=null)
                if (data_headers != null)
                {
                //customerEntities.InvoiceDetails.Remove(data_details);
                customerEntities.InvoiceHeaders.Remove(data_headers);
                customerEntities.SaveChanges();
                result = "success";
            }
            return result;
        }
     
        
        public CA.InvoiceHeaderModel EditInvoice(int invoiceNumber)
        {
            string result = string.Empty;
            CA.InvoiceHeaderModel model = new CA.InvoiceHeaderModel();
            var data = customerEntities.InvoiceHeaders.Where(x => x.InvoiceNumber == invoiceNumber).FirstOrDefault();
            if (data != null)
            {   
                model.InvoiceNumber = data.InvoiceNumber;
                model.InvoiceDate = data.InvoiceDate;
                model.NetTotal = data.NetTotal;
                model.CustomerCode = data.CustomerCode;
                model.CustomerName = data.CustomerName;  
                result = "Success";
            }
            return model;

        }

    }
}
