using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA=ConsumerDA;
using CA=ConsumerEntities;

namespace ConsumerBC
{
   public class ProductBC
    {
        DA::ProductDA productDA = new DA.ProductDA();
       public List<CA::ProductModel> LoadAll()
        {
            return productDA.LoadAll();
        }
        public string AddItem(CA.ProductModel productModel)
        {
            return productDA.AddItem(productModel);
        }
        public CA.ProductModel Edit(int ProductCode)
        {
            return productDA.Edit(ProductCode);
        }
        public string Delete(int ProductCode)
        {
            return productDA.Delete(ProductCode);
        }

    }
}
