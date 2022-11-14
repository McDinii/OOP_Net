using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_05
{
    public class Printer
    {
        public static void IAmPrinting(ITransport element)
        {
            if (element is TransportVehicle)
            {
                Console.WriteLine($"Type object({element.GetType()}): " + element);
            }
            else
            {
                var temp = element as Transformer;
                if (temp != null)
                    Console.WriteLine($"Type object({temp.GetType()}): " + temp);
            }
        }
    }
}
