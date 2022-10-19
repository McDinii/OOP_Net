using System.Reflection;
using System.Security.Cryptography;

namespace Laba_04 
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t1(IT)");
            var engine = new Engine("volkswagen", 457);
            var car = new Car(4, "car", engine, 100, 10);

            car.SpeedControl();
            ((ITransport)car).SpeedControl(); // явный интерфейс
            ITransport iTransport = car;
            iTransport.SpeedControl();

            var Porsche = new Car(4, "Porsche", engine, 412.4, 23);
            var superEngine = new Engine("XE-45A", 5812);
            var transformer = new Transformer(superEngine, "Optimus", new DateTime(2004, 5, 16), 5476);

            Console.WriteLine("\t2(is)");
            if (Porsche is CarControl)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(false);
            }

            if (Porsche is ITransport)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(false);
            }

            if (Porsche is Human)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(false);
            }

            Console.WriteLine("\t3(as)");

            ITransport iCar = Porsche;
            if (iCar as Car != null)
            {
                Console.WriteLine($"({iCar}) as car\n");
            }

            Console.WriteLine("\t4(Print)");

            var array = new ITransport[] { Porsche, car, transformer };

            foreach (var e in array)
            {
                Printer.IAmPrinting(e);
            }

            Console.WriteLine("\t5(car)");
            Porsche.Drive();
            Porsche.Launch();
            Porsche.Drive();
            Porsche.Shutdown();

        }
    }
}