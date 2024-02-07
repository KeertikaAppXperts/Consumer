//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CE=ConsumerEntities

//namespace Consumer.Repository
//{
//    public class CustomerRepository
//    {
//        private readonly CE::CustomerEntities customerEntities;
//        public CustomerRepository()
//        {
//            customerEntities = new CE.CustomerEntities();
//        }
//        public IEnumerable<SelectListItem> GetAllCustomers()
//        {
//            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();

//            objSelectListItems = (
//                                    from obj in customerEntities.CustomerDetails
//                                    select new SelectListItem
//                                    {
                                     
//                                        Text = obj.CustomerName,
//                                        Value = obj.CustomerName.ToString(),
//                                        Selected = true
//                                    }
//                                ).ToList();

//            return objSelectListItems;
//        }
//    }
//}