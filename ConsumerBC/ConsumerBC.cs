using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA = ConsumerDA;
using CE = ConsumerEntities;

namespace ConsumerBC
{
    public class ConsumerBC
    {
        DA::ConsumerDA _DA = new DA.ConsumerDA();
        public List<CE::ConsumerModel> GetAll()
        {
            return _DA.Getall();
        }
       public string Add(CE.ConsumerModel consumerModel )
        {
            return _DA.Add(consumerModel);
        }

        public CE.ConsumerModel Edit(int CustomerCode)
        {

            return _DA.Edit(CustomerCode);

        }

        public string Delete(int CustomerCode)
        {
            return _DA.Delete(CustomerCode);
        }
        

    }
}   