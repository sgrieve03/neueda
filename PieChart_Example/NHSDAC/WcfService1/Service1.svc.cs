using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        NHSDAC.NHSPatientServicesEntities db; 

        public Service1()
        {
            db = new NHSDAC.NHSPatientServicesEntities();
        }

        public List<CoOrdinates> GetCoOrdinates()
        {
            List<CoOrdinates> coOrds = new List<CoOrdinates>();
            CoOrdinates set;
            var points = from p in db.Organisation_Details
                         select new { Name = db.Organisation_Details.Ref_Organisation_Type_ID.average(), Value = p.Organisation_Name };

            foreach (var p in points)
            {
                set = new CoOrdinates(p.Name , p.Value);
                coOrds.Add(set);
            }
            return coOrds;
                  
        }

        public string[] GetData()
        {
            string[] myArray = new string[10];
            List<string> myList = new List<String>(from a in db.Organisation_Details select a.Address.Address_Line_1);
            int i = 0;
            foreach (string s in myList)
            {
                myArray[i] = s;
                if (i < 9) { i++; }

            }

            return myArray;
        }

    }

}
