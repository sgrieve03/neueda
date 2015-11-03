using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NHSPatientServicesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<PlottableObject> GetData(int value);

        

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class PlottableObject
    {
        private int? average;
        private string v;

        public PlottableObject(string v, int? average)
        {
            this.v = v;
            this.average = average;
        }

        [DataMember]
        public int Ref_ID { get; set; }
        [DataMember]
        public int value { get; set; }
      
        
      
    }
}
