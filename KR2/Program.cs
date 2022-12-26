namespace KR2
{
    class Program
    {
        class SuperList<T> : List<T> where T : class
        {

            public static SuperList<T> operator +(SuperList<T> list, T el)
            {
                Console.WriteLine("add " + el);
                if (list.Count >= 5)
                {
                    throw new IndexOutOfRangeException("list is full, cant add " + el);
                }
                else
                {
                    list.Add(el);
                }
                return list;

            }


        }
        class Doctor
        {
            public delegate void Help();
            public event Help sayHeal;
            public const double NormalTemp = 36.6;
            public void doHealing(double tem, Patient patient)
            {
                if (tem > NormalTemp)
                {
                    Console.WriteLine("Doc said i need heal");
                    
                    sayHeal?.Invoke();

                    double min = tem - NormalTemp;
                    tem -= min;
        
                }
                else
                    Console.WriteLine("U dont need healing");
                patient.Tempture = tem;
            }



        }

        class Patient
        {
            public static  int Id = 0;
            public string Name;
            public double Tempture;
            public Patient()
            {
                Id++;
                Name = "Patient" + Convert.ToString(Id);
                Tempture = 36.6;
            }
            public Patient (string name,double el)
            {
                Name = name;
                Tempture = el;
            }
            public void Heal()
            {

                Console.WriteLine("Doc is healing me");
            }
            public void MyTemp()
            {
                Console.WriteLine("My tempreture is " + Tempture);
            }

        }
        static void Main()
        {

            try
            {
                Console.WriteLine("Task 1");
                SuperList<string> list = new SuperList<string>();
                list.Add("word");
                list.Add("hello");

                list += "bye";
                list.Add("hello");
                foreach (string s in list)
                    Console.WriteLine(s);


                Console.WriteLine("\nTask 2");
                Console.WriteLine("El equals hello");
                Console.WriteLine(list.First(p => p == "hello"));

                Console.WriteLine("\nTask 3");

                Doctor doc = new Doctor();
                Patient person = new Patient();
                doc.sayHeal += person.Heal;
                Console.WriteLine("for " + person.Name);
                person.MyTemp();
                doc.doHealing(person.Tempture,person);
                person.MyTemp();
                Patient person2 = new Patient("Denis", 41);
                Console.WriteLine("\nfor " + person2.Name);
                person2.MyTemp();
                doc.doHealing(person2.Tempture, person2);
                person2.MyTemp();



            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("error:" + e.Message);
            }
            finally
            {
                Console.WriteLine("end of tasks");
            }


        }
    }

}