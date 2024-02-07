using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BC = ConsumerBC;
using CE = ConsumerEntities;

namespace Consumer.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        BC::ProductBC productBC = new BC.ProductBC();
        CE::CustomerEntities customerEntities = new CE.CustomerEntities();
        public ActionResult ProductView()
        {
            return View();
        }
        //public ActionResult ProductView()
        //{
        //    return View();
        //}
        public JsonResult LoadAll()
        {
            List<CE::ProductModel> data = productBC.LoadAll();
            return Json(data);
        }
        public JsonResult Add(string header)
        {
            CE.ProductModel data = new CE.ProductModel();
            if(!string.IsNullOrEmpty(header))
            {
                data = CustomerJson<CE::ProductModel>.JsonToSingleOrDefault(header);
;            }
            string result = productBC.AddItem(data);
            return Json(result);
        }
        public JsonResult EditProduct(int header)
        {
            CE.ProductModel data = new CE.ProductModel();
            if(header>0)
            {
                data = productBC.Edit(header);
            }
            return Json(data);
        }
        public JsonResult DeleteProduct(int ProductCode)
        {
            string result = string.Empty;
            if (ProductCode > 0)
            {
                result = productBC.Delete(ProductCode);
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult GetProductName(string productpassed)
        {
            var productvar = (from x in customerEntities.Products where x.ProductName.StartsWith(productpassed) select new { label = x.ProductName }).ToList();
            return Json(productvar);
        }
        [HttpGet]
        public JsonResult GetProductPrice(int Item)
        {
            decimal price = customerEntities.Products.Single(x => x.ProductCode == Item).Price;
            return Json(price, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        // public JsonResult GetProductPrice(int Item)
        //{
        //    decimal price = customerEntities.Products.Single(x => x.ProductCode == Item).Price;       
        //    return Json(price, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetCustomerAddressDetails(string header)
        //{
        //    string aa = header;
        //    CE::ConsumerModel model = new CE.ConsumerModel();
        //    var data = customerEntities.CustomerDetails.Where(x => x.CustomerCode == Convert.ToInt32(header)).FirstOrDefault();
        //    if (data != null)
        //    {
        //        model.Address = data.Address;
        //        model.City = data.City;
        //    }
        //    return Json(data);


         }
    }
