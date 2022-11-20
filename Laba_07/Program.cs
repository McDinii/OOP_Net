using System.Collections.Generic;

namespace Laba_07
{
    class Program
    {
       public static void Main()
        {

            try
            {
                var mySet = new MiSet<string>("test");
                Console.WriteLine(mySet[0]);
         
                var setTransformer = new MiSet<Transformer>(
                    new Transformer(123, "Optimus",
                        new DateTime(2022, 10, 3), 432));

                var transformer = new Transformer(523, "Bambulbi",
                    new DateTime(2022, 10, 3, 12, 13, 13), 4412);
                setTransformer.Add(transformer);

                Console.WriteLine("\nbefore delete view\n");
                setTransformer.View();
                Console.WriteLine("\nafter delete view\n");
                setTransformer.Remove(transformer);
                setTransformer.View();

                MiSet<Transformer>.WriteToFile(ref setTransformer);

                Console.WriteLine("from file");
                MiSet<Transformer>.ReadFromFile();

                Console.WriteLine(mySet[-1]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("end try-catch-finally");
            }
        }
    }
}