using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NHSPatServices
{
    
    public class Service1 : IService1
    {
        NHSPatServ.NHSPatientServicesEntities dbContext = new NHSPatServ.NHSPatientServicesEntities();

        public List<MappableObject> GetMappableObjects(search searchQuery)
        {
            List<MappableObject> myList = new List<MappableObject>();
            MappableObject pobj;
            var result = dbContext.Locations.FirstOrDefault();
            pobj = new MappableObject(result.Latitude, result.Longtitude, result.Ref_Organisation_Details_ID.ToString());
            myList.Add(pobj);
            return myList ;
            
        }

     

        public List<PlottableObject> GetPlottableObjects(search searchQuery)
        {
            PlottableObject obj;
            List<PlottableObject> objList = new List<PlottableObject>();

            switch (searchQuery)
            {
                case search.AverageAllDiseaseInEngland:
                    try
                    {
                        var result = dbContext.sp_All_England_Disease_Avg();

                        if (result != null)
                        {
                            foreach (var r in result)
                            {
                                obj = new PlottableObject(r.Disease_Name.TrimEnd(), (int)r.average);
                                objList.Add(obj);

                            }
                        }
                    }
                    catch { Exception ex; }
                    break;

                case search.AverageAllDiseaseInNHSTrust:

                    break;
                case search.AveragePatientInEngland:
                    break;
                case search.AveragePatientInNHSTrust:
                    break;
                case search.AverageRatingInEngland:
                    break;
                case search.AverageRatingInTrust:
                    break;
                case search.AverageSpecificDiseaseInEngland:

                    //try
                    //{
                    //    var result = dbContext.sp_Specified_England_Disease_Avg(diseaseQuery.ToString());

                    //    if (result != null)
                    //    {
                    //        foreach (var r in result)
                    //        {
                    //            obj = new PlottableObject(r.Disease_Name.TrimEnd(), (int)r.average);
                    //            objList.Add(obj);

                    //        }
                    //    }
                    //}
                    //catch { Exception ex; }
                    //break;
                case search.AverageSpecificDiseaseInNHSTrust:
                    break;
                case search.AverageStaffInEngland:
                    break;
                case search.AverageStaffInNHSTrust:
                    break;
                case search.MaxAllDiseaseInEngland:
                    break;
                case search.MaxAllDiseaseInNHSTrust:
                    break;
                case search.MaxSpecificDiseaseInEngland:
                    break;
                case search.MaxSpecificDiseaseInNHSTrust:
                    break;
                case search.MinAllDiseaseInEngland:
                    break;
                case search.MinAllDiseaseInNHSTrust:
                    break;
                case search.MinSpecificDiseaseInEngland:
                    break;
                case search.MinSpecificDiseaseInNHSTrust:
                    break;
                case search.TotalAllDiseaseInSpecificGP:
                    break;
                case search.TotalPatientInSpecificGP:
                    break;
                case search.TotalRatingInGP:
                    break;
                case search.TotalSpecificDiseaseInGP:
                    break;
                case search.TotalStaffInSpecificGP:
                    break; 
            }
            
            return objList;
        }
    }

   
}
