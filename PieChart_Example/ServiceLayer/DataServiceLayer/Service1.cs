using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DataServiceLayer
{
    public class Service1
    {
        NHSPatientServicesEntities dbContext;


        public Service1() {

            dbContext = new NHSPatientServicesEntities();

        }//service1
        
        public List<GraphCoOrdinate> GetCoOrdinates(AxisEnums one, AxisEnums two)
        {
            List<GraphCoOrdinate> listOfDiseasePrevalance = new List<GraphCoOrdinate>();
            GraphCoOrdinate currentCoOrd;
            switch (one)
            {
                case AxisEnums.NumPatients:
                    switch (two)
                    {
                        case AxisEnums.DiseasePrevalance:
                            break;
                        case AxisEnums.NumStaff:
                            break;
                        case AxisEnums.PatientSatisfaction:
                            break;                      
                    }
                    break;
                case AxisEnums.DiseasePrevalance:
                    switch (two)
                    {
                        case AxisEnums.NumPatients:
                            break;
                        case AxisEnums.NumStaff:
                            break;
                        case AxisEnums.PatientSatisfaction:
                            break;
                    }
                    break;
                case AxisEnums.NumStaff:
                    switch (two)
                    {
                        case AxisEnums.DiseasePrevalance:
                            break;
                        case AxisEnums.NumPatients:
                            break;
                        case AxisEnums.PatientSatisfaction:
                            break;
                    }
                    break;
                case AxisEnums.PatientSatisfaction:
                    switch (two)
                    {
                        case AxisEnums.DiseasePrevalance:
                            break;
                        case AxisEnums.NumStaff:
                            break;
                        case AxisEnums.NumPatients:
                            break;
                    }
                    break;
            }
            try
            {
                foreach(var r in dbContext.GP_Disease_Prevalence)
                {
                    currentCoOrd= new GraphCoOrdinate(r.GP_Practice_Code.ToString(), r.Number_of_cases);
                    listOfDiseasePrevalance.Add(currentCoOrd);
                }
            }
            catch { Exception ex; }

            return listOfDiseasePrevalance;

        }

        public String getgpid()
        {
            try
            {
                var ab= (String)(from a in dbContext.GP_Disease_Prevalence select a.Disease_Name).FirstOrDefault();
                return ab;

            }
            catch { Exception ex; }
            
            return "doesnt work";
        }





    } }