using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NHSPatServices
{
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        List<PlottableObject> GetPlottableObjects(search searchQuery);
        [OperationContract]
        List<MappableObject> GetMappableObjects(search searchQuery);
    }//end service

    [DataContract]
    public class PlottableObject
    {
        [DataMember]
        public string Ref_ID { get; set; }
        [DataMember]
        public int Value { get; set; }


        public PlottableObject(string value, int average)
        {
            Ref_ID = value;
            Value = average;
        }
    }//end plottableObject
    [DataContract]
    public class disease
    {
        [DataMember]
    public string Name { get; set; }
        [DataMember]
    public diseaseEnum Code { get; set; } 

    public disease(string name)
    {
        this.Name = name;
        this.Code = diseaseEnum.AST;
    }
    public disease(string name, diseaseEnum code)
    {
            this.Name = name;
            this.Code = code;
    }

    }
    [DataContract]
    public enum search
    {
        [EnumMember]
        AverageAllDiseaseInEngland,
        [EnumMember]
        MaxAllDiseaseInEngland,
        [EnumMember]
        MinAllDiseaseInEngland,
        [EnumMember]
        AverageSpecificDiseaseInEngland,
        [EnumMember]
        MaxSpecificDiseaseInEngland,
        [EnumMember]
        MinSpecificDiseaseInEngland,
        [EnumMember]
        AverageAllDiseaseInNHSTrust,
        [EnumMember]
        MaxAllDiseaseInNHSTrust,
        [EnumMember]
        MinAllDiseaseInNHSTrust,
        [EnumMember]
        AverageSpecificDiseaseInNHSTrust,
        [EnumMember]
        MaxSpecificDiseaseInNHSTrust,
        [EnumMember]
        MinSpecificDiseaseInNHSTrust,
        [EnumMember]
        TotalAllDiseaseInSpecificGP,
        [EnumMember]
        TotalSpecificDiseaseInGP,
        [EnumMember]
        AverageStaffInEngland,
        [EnumMember]
        AverageStaffInNHSTrust,
        [EnumMember]
        TotalStaffInSpecificGP,
        [EnumMember]
        AveragePatientInEngland,
        [EnumMember]
        AveragePatientInNHSTrust,
        [EnumMember]
        TotalPatientInSpecificGP,
        [EnumMember]
        AverageRatingInEngland,
        [EnumMember]
        AverageRatingInTrust,
        [EnumMember]
        TotalRatingInGP

    }//end search
    [DataContract]
    public enum diseaseEnum
    {

        [EnumMember]
        AST,
        [EnumMember]
        Chronic,
        [EnumMember]
        THY,
        [EnumMember]
        HYP,
        [EnumMember]
        DEM,
        [EnumMember]
        OST,
        [EnumMember]
        AF,
        [EnumMember]
        HF,
        [EnumMember]
        LD,
        [EnumMember]
        CHD,
        [EnumMember]
        EP,
        [EnumMember]
        CKD,
        [EnumMember]
        RA,
        [EnumMember]
        DEP,
        [EnumMember]
        DM,
        [EnumMember]
        CAN,
        [EnumMember]
        SMOK,
        [EnumMember]
        STIA,
        [EnumMember]
        PA,
        [EnumMember]
        MH,
        [EnumMember]
        PAD,
        [EnumMember]
        OB,
        [EnumMember]
        CVDPP

    }//end disease
    [DataContract]
    public class MappableObject
    {
        [DataMember]
        double Longitude { get; set; }
        [DataMember]
        double Latitude { get; set; }
        [DataMember]
        string info { get; set; }

        public MappableObject(double Longitude, double Latitude, string info)
        {
            this.Longitude = Longitude;
            this.Latitude =  Latitude;
            this.info = info;
        }
    }
}//end class
