using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA = ConsumerEntities;

namespace ConsumerDA
{
    public class ProductDA
    {
        CA::CustomerEntities customerEntities = new CA.CustomerEntities();
        public List<CA::ProductModel> LoadAll()
        {
            List<CA::ProductModel > objProduct = new List<CA.ProductModel>();
            var datalist = customerEntities.Products.ToList(); 
                if (datalist != null & datalist.Count() > 0)
                {
                datalist.ForEach(item =>
                {
                    objProduct.Add(new CA.ProductModel
                    {
                        ProductCode = item.ProductCode,
                        ProductName = item.ProductName,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Total = item.Total
                    });

                });
                }
          return objProduct ;
        }
 //adding  and editing a  product
        public string AddItem(CA.ProductModel obj)
        {
            string result = string.Empty;
            if(obj!=null)
            {
                var data = customerEntities.Products.Where(x => x.ProductCode == obj.ProductCode).FirstOrDefault();
                if(data!=null){
                    data.ProductName = obj.ProductName;
                    data.Price = obj.Price;
                    data.Quantity = obj.Quantity;
                    data.Total = obj.Total;
                    customerEntities.SaveChanges();
                }
                else
                {
                    CA.Product product = new CA.Product()
                    {
                        ProductName = obj.ProductName,
                        Price = obj.Price,
                        Quantity = obj.Quantity,
                        Total = obj.Total,
                    };
                    customerEntities.Products.Add(product);
                    customerEntities.SaveChanges();
                    result = "succcess";
                }
            }
            return result;
        }

        //loading data for editing
        public CA.ProductModel Edit(int ProductCode)
        {
            string result = string.Empty;
            CA.ProductModel model = new CA.ProductModel();
            var data = customerEntities.Products.Where(x => x.ProductCode == ProductCode).FirstOrDefault();
            if (data != null)
            {
                model.ProductCode = data.ProductCode;
                model.ProductName = data.ProductName;
                model.Price = data.Price;
                model.Quantity = data.Quantity;
                model.Total = data.Total;
                result = "Success";
            }
            return model;

        }

        //deleting a product
        public string Delete(int ProductCode)
        {
            string result = string.Empty;
            var data = customerEntities.Products.Where(y => y.ProductCode == ProductCode).FirstOrDefault();
            if(data!=null)
            {
                customerEntities.Products.Remove(data);
                customerEntities.SaveChanges();
                result = "success";
            }
            return result;
        }
    }
}
