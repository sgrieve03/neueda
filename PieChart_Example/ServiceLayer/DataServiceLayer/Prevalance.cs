using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    class Prevalance
    {
        public int GP_Disease_PrevalenceID { get; set; }
        public Nullable<int> Ref_ { get; set; }
        public string Indicator_Group { get; set; }
        public string Disease_Name { get; set; }
        public int Number_of_cases { get; set; }

    }
}
