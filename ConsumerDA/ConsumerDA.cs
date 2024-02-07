using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA = ConsumerEntities;


namespace ConsumerDA
{
    public class ConsumerDA
    {
        CA::CustomerEntities objCustomerEntities = new CA::CustomerEntities();
        public List<CA::ConsumerModel> Getall()
        {
            List<CA::ConsumerModel> objcustomer = new List<CA::ConsumerModel>();
            try
            {
                var datalist = objCustomerEntities.CustomerDetails.ToList();
                if (datalist != null && datalist.Count() > 0)
                {
                    datalist.ForEach(item =>
                    {
                        objcustomer.Add(new CA::ConsumerModel
                        {

                            CustomerCode = item.CustomerCode,
                            CustomerName = item.CustomerName,
                            Mobile = item.Mobile,
                            Email = item.Email,
                            Address = item.Address,
                            City = item.City,
                            Gender = item.Gender,
                            Country = item.Country
                        });
                    });


                }
            }
            catch (Exception ex)
            {

            }
            return objcustomer;
        }
        public string Add(CA.ConsumerModel customerDetail)
        {
            string result = string.Empty;
            if (customerDetail != null)
            {
                var data = objCustomerEntities.CustomerDetails.Where(x => x.CustomerCode == customerDetail.CustomerCode).FirstOrDefault();
                if (data != null)
                {
                    data.CustomerCode = customerDetail.CustomerCode;
                    data.CustomerName = customerDetail.CustomerName;
                    data.Mobile = customerDetail.Mobile;
                    data.Email = customerDetail.Email;
                    data.Address = customerDetail.Address;
                    data.City = customerDetail.City;
                    data.Gender = customerDetail.Gender;
                    data.Country = customerDetail.Country;
                    objCustomerEntities.SaveChanges();
                }
                else
                {

                    CA.CustomerDetail custdetobj = new CA.CustomerDetail()
                    {
                        CustomerCode = customerDetail.CustomerCode,
                        CustomerName = customerDetail.CustomerName,
                        Mobile = customerDetail.Mobile,
                        Email = customerDetail.Email,
                        Address = customerDetail.Address,
                        City = customerDetail.City,
                        Gender = customerDetail.Gender,
                        Country = customerDetail.Country,

                    };

                    objCustomerEntities.CustomerDetails.Add(custdetobj);
                    objCustomerEntities.SaveChanges();
                    result = "Success";
                }
            }
            return result;

        }
        public CA.ConsumerModel Edit(int CustomerCode)
        {
            string result = string.Empty;
            CA.ConsumerModel model = new CA.ConsumerModel();
            var data = objCustomerEntities.CustomerDetails.Where(x => x.CustomerCode == CustomerCode).FirstOrDefault();
            if (data != null)
            {
                model.CustomerCode = data.CustomerCode;
                model.CustomerName = data.CustomerName;
                model.Mobile = data.Mobile;
                model.Email = data.Email;
                model.Address = data.Address;
                model.City = data.City;
                model.Gender = data.Gender;
                model.Country = data.Country;
                result = "Success";
            }
            return model;

        }
        public String Delete(int CustomerCode)
        {
            string result = string.Empty;
             var data = objCustomerEntities.CustomerDetails.Where(x => x.CustomerCode == CustomerCode).FirstOrDefault();
            if (data != null)
            {
                objCustomerEntities.CustomerDetails.Remove(data);
                objCustomerEntities.SaveChanges();
                result = "Success";
            }
             return result;
        }
        //public CA.ConsumerModel GetCustomerDetails(int Item)
        //{
        //    string result = string.Empty;
        //    CA.ConsumerModel model = new CA.ConsumerModel();
        //    var data = objCustomerEntities.CustomerDetails.Where(x => x.CustomerCode == Item).FirstOrDefault();
        //    if (data != null)
        //    {
        //        model.Address=data.Address;
        //        model.City=data.City;
        //    }
        //    return model;
        //}
    }
}
