using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 s = new Service1();
            //List<GraphCoOrdinate> gcord;
            //GraphCoOrdinate gco;

            //gcord=s.GetDiseasePrevalance("Thyroid");

            //foreach (GraphCoOrdinate a in gcord) {

            //    gco = a;
            //    Console.Write(a.item, a.value);
            //}
            Console.WriteLine(s.getgpid());
            Console.Read();

        }
    }
}
