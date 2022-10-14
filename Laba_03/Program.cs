namespace Laba_04
{
    class Program
    {
       public static void Main()
        {

            var set1 = new MiSet("1");
            set1.DeveloperInitialization("Petya", 1, "Mobail"); // инициализируем экземпляр вложенного класса с помощью метода
            MiSet.Developer dev = new MiSet.Developer("Vasik", 2, "Gamer"); // инициализируем экземляр вложенного класса 

            Production zz = new Production(2, "Amazon"); // инициализируем экземпляр 

            var set2 = new MiSet("D"); // инициализуем множество типа MiSet
            set2.ProductionInitialization(32, "Spotify"); // инициализируем экземпляр вложенного объекта с помощью метода
            set2 += "e";
            set2 += "n";
            set2 += "i";
            set2 += "s";

            var set3 = new MiSet("Ne");
            set3 += "chay";
            set3 += "-";
            set3 += "Nits";
            set3 += "ev";
            set3 += "ich";

            var set4 = new MiSet("He");
            set4 += "l";
            set4 += "";
            set4 += "lo";

            Console.WriteLine("-------------Developer and Production---------------");
            Console.WriteLine("Developer( name: {0}, id: {1}, department: {2})",
                set1.developer.Name, set1.developer.Id, set1.developer.Department);
            Console.WriteLine("Production( id: {0}, organization: {1})",
                set2.production.Id, set2.production.Organization);
            Console.WriteLine();

            Console.WriteLine("get and set (indexer)");
            set3.Print();
            Console.WriteLine("index value to print: ");
            var index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(set3[index]); 

            Console.WriteLine("index value to refactor: ");
            index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("new value to set3[{0}]: ", index);
            set3[index] = Console.ReadLine();
            set3.Print();
            Console.WriteLine();

            Console.WriteLine("AddComma");
            Console.WriteLine("before update");
            set2.Print();
            set2.AddComma();
            Console.WriteLine("after update");
            set2.Print();
            Console.WriteLine();

            Console.WriteLine("Distinct");
            Console.WriteLine("before update");
            set3.Print();
            set3.Distinct();
            Console.WriteLine("after update");
            set3.Print();
            Console.WriteLine();

            Console.WriteLine("max and min(LEN)");
            set4.Print();
            Console.WriteLine("max: {0} --- min: {1}", set4.Max(), set4.Min());
            Console.WriteLine();

            Console.WriteLine("difference");
            set4.Print();
            Console.WriteLine("Difference: {0}", set4.Difference());

            Console.WriteLine("Count Of Items");
            Console.WriteLine("Count Of Words: {0}", set1.CountItem());

            Console.WriteLine("operators");
            Console.WriteLine("set2: ");
            set2.Print();
            Console.WriteLine();
            Console.WriteLine("old set3: ");
            set3.Print();
            Console.WriteLine();
            Console.WriteLine("\t\tset + set");
            set3 += set2;

            Console.WriteLine("new set3: ");
            set3.Print();

            Console.WriteLine("\t\tset * set");
            set3 *= set2;
            set3.Print();

            Console.WriteLine("\t\t(int)set");
            Console.WriteLine((int)set3);

            Console.WriteLine("\t\ttrue and false");
            Console.WriteLine(set1 ? "true" : "false");
            set3 += "x";
            set3 += "y";
            set3 += "z";
            Console.WriteLine(set3 ? "true" : "false");
        }
    }
}