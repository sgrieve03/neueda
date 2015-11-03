using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class GraphCoOrdinate
    {
        public string item { get; set; }
        public double value { get; set; }

        public GraphCoOrdinate(string item, double value) {
            this.item = item;
            this.value = value;
        }


    }
}
