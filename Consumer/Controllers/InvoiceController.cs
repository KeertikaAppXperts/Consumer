using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BC = ConsumerBC;
using CE = ConsumerEntities;


namespace Consumer.Controllers
{
    public class InvoiceController : Controller
    {
        CE::CustomerEntities customerEntities = new CE.CustomerEntities();
        CE::InvoiceHeaderModel invoiceHeaderModel = new CE.InvoiceHeaderModel();
        BC::InvoiceHeaderBC invoiceHeaderBC = new BC.InvoiceHeaderBC();

        public ActionResult InvoiceDemo()
        {
            return View();
        }
      
        public ActionResult Invoice()
        {
            return View();
        }
        public JsonResult ShowAll()
        {
            List<CE::InvoiceHeaderModel> data = invoiceHeaderBC.ShowAll_InvoiceHeaderBC();
            return Json(data);

        }
        public JsonResult GetCustomerInvoice(int invoiceNumber)
        {

            CE.InvoiceHeader InvoiceHeader_data = customerEntities.InvoiceHeaders.Where(x => x.InvoiceNumber == invoiceNumber).FirstOrDefault();
            return Json(InvoiceHeader_data , JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveInvoiceController(string header, string detail)
        {
            CE.InvoiceHeaderModel data = new CE.InvoiceHeaderModel();
            List<CE::InvoiceDetailModel> Item = new List<CE.InvoiceDetailModel>();
            if (!string.IsNullOrEmpty(header))
            {
                data = CustomerJson<CE::InvoiceHeaderModel>.JsonToSingleOrDefault(header);
            }
            //CE.InvoiceDetailModel Item = new CE.InvoiceDetailModel();
            if (detail != null)
            {
                Item = CustomerJson<CE::InvoiceDetailModel>.JsonToList(detail) ;
            }
            string result = invoiceHeaderBC.SaveInvoiceBC(data, Item);
            return Json(result);
        }
        public JsonResult DeleteInvoiceController(int invoiceNumber)
        {
            string result = string.Empty;
            if (invoiceNumber > 0)
            {
                result = invoiceHeaderBC.DeleteInvoiceBC(invoiceNumber);
            }
            return Json(result);
        }
        [HttpGet]
      
        public JsonResult EditInvoiceContoller(int InvoiceNumber)
        {
            string result = string.Empty;
            CE::InvoiceHeaderModel _data = new CE.InvoiceHeaderModel();
            if (InvoiceNumber > 0)
            {
                _data = invoiceHeaderBC.EditInvoiceBC(InvoiceNumber);
            }
            return Json(_data);
        }


    }
}
