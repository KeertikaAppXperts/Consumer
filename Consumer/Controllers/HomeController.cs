using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BC = ConsumerBC;
using CE = ConsumerEntities;

namespace Consumer.Controllers
{
    public class HomeController : Controller
    {

        BC::ConsumerBC _BC = new BC.ConsumerBC();
        CE::CustomerEntities customerEntities = new CE.CustomerEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            List<CE::ConsumerModel> data = _BC.GetAll();
            return Json(data);

        }
        public JsonResult AddCustomer(string header)
        {
            CE::ConsumerModel _data = new CE.ConsumerModel();
            if (!string.IsNullOrEmpty(header))
            {
                _data = CustomerJson<CE::ConsumerModel>.JsonToSingleOrDefault(header);
            }
            string result = _BC.Add(_data);
            return Json(result);

        }

        public JsonResult EditCustomer(int header)
        {
            string result = string.Empty;
            CE::ConsumerModel _data = new CE.ConsumerModel();
            if (header > 0)
            {
                _data = _BC.Edit(header);
            }
            return Json(_data);
        }

        public JsonResult RemoveCustomer(int CustomerCode)
        {
            string result = string.Empty;
            if (CustomerCode > 0)
            {
                result = _BC.Delete(CustomerCode);
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetCustomerAddress(int Item)
        {
            CE.CustomerDetail Address = customerEntities.CustomerDetails.Where(x => x.CustomerCode == Item).FirstOrDefault();
            return Json(Address, JsonRequestBehavior.AllowGet);
        }
       // [HttpGet]
        //public JsonResult GetCustomerCity(int Item)
        //{
        //    string Place = customerEntities.CustomerDetails.Single(x => x.CustomerCode == Item).City;
        //    return Json(Place, JsonRequestBehavior.AllowGet);
        //}
        
        //public JsonResult GetCustomerAddress(int Item)
        //{
        //    CE.CustomerDetail data = customerEntities.CustomerDetails.Where(x => x.CustomerCode == Item).FirstOrDefault();
        //    CE::ConsumerModel model = new CE.ConsumerModel();
        //    //var data = customerEntities.CustomerDetails.Where(x => x.CustomerCode == Convert.ToInt32(header)).FirstOrDefault();
        //    if (data != null)
        //    {
        //        model.Address = data.Address;
        //        model.City = data.City;
        //    }
        //    return Json(data);
        //}
        //[HttpPost]
        //public JsonResult GetMobile(string mobilein)
        //{
        //    var Mob = (from x in customerEntities.CustomerDetails where x.Mobile.StartsWith(mobilein) select new { label = x.Mobile }).ToList();
        //    return Json(Mob);
        //}
        //public JsonResult GetCustomerDetails(int Item)
        //{
        //    string result = string.Empty;
        //    CE::ConsumerModel data = new CE.ConsumerModel();
        //    if (Item>0)
        //    {
        //        data = _BC.GetCustomerDetails(Item);
        //    }

        //    return Json(result);
        //}


    }
    }
