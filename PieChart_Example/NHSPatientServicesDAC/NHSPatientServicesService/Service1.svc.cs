using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NHSPatientServicesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        NHSPatientServicesDAC.NHSPatientServicesEntities3 dbContext = new NHSPatientServicesDAC.NHSPatientServicesEntities3();

        public List<PlottableObject> GetData(int value)
        {
            PlottableObject obj;
            List<PlottableObject> objList = new List<PlottableObject>();
            try {
                var result = dbContext.spNHSTrustAST();
            
            if (result != null)
            {
                foreach (var r in result)
                {
                    obj = new PlottableObject(r.Ref_Parent_ID.ToString(), r.average);
                    objList.Add(obj);

                }
            }
            }
            catch { Exception ex; }
            return objList;
        }

    }
}
