using System.Security.Cryptography;

namespace task12
{
    class Program
    {
        public interface IGetIt
        {
            public void Read();
            public void Print();

        }
        
        public class Address
        {
           public string Fio { get;set;}
           public string Email { get;set;}
            public override string ToString()
            {
                return $"{Email }, {Fio} ";
            }

        }
        public class Letter : IGetIt
        {
            public Letter(string sub,string txt, Address addTo, Address addFrom,string sign )
            {
                Subject = sub;
                Text = txt;
                adressTo = addTo;
                adressFrom = addFrom;
                signature = sign;
                
            }
            public string Subject { get; set;}
            public string Text { get; set;}
            public Address adressTo;
            public Address adressFrom;
           

            public string signature;
            public override string ToString()
            {
                return $"Subject:{Subject} \n" +
                    $"{Text} \n" +
                    $"From:{adressFrom} \n" +
                    $"To:{adressTo} \n" +
                    $"signature:{signature} \n\n";
            }
            public  void Read()
            {
                Console.WriteLine( $"Subject:{Subject} \n" +
                    $"{Text} \n" +
                    $"From:{adressFrom} \n" +
                    $"To:{adressTo} \n" +
                    $"signature:{signature} \n\n");
            }
           
            public void Print()
            {
                using ( StreamWriter file = new StreamWriter("file.txt",false))
                {
                    file.WriteLine($"Subject:{Subject} \n" +
                    $"{Text} \n" +
                    $"From:{adressFrom} \n" +
                    $"To:{adressTo} \n" +
                    $"signature:{signature} \n\n");
                }
            }

            public override bool Equals(object? obj)
            {   
                Letter let2 =  obj as Letter;
                return Text == let2.Text && signature ==let2.signature;
            }
        }
         public class Box
        {
            public List<Letter> lets = new List<Letter>();
            public void Add(Letter let)
            {
                lets.Add(let);
            }

            public bool Unic()
            {

                for (int i = 0; i < lets.Count; i++)
                {
                    for (int j = 1; j < lets.Count; j++)
                    {
                        if (lets[i].Equals(lets[j]))
                            return true;
                    }
                }
                return false;

            }
        }
        static void Main()
        {   // Task 1
            Address me = new Address { Fio = "Nechay", Email = "NN@.com"};
            Address mom = new Address { Fio = "Mom", Email = "mom@.com"};
            Address dad = new Address { Fio = "Dad", Email = "dad@.com"};

            Letter myLetter = new Letter("Work question","Hello,Dear,Daddy",dad,me,"Dinii");
            Letter letterMy = new Letter("Cook question","Hello,Dear,Mommy",mom,me,"Dinii");
            // Task 2
            myLetter.Read();
            letterMy.Read();
            myLetter.Print();
            letterMy.Print();
            Console.WriteLine(myLetter.Equals(myLetter));
            Console.WriteLine(myLetter.Equals(letterMy));
            
            // Task 3
            Box lets = new Box();
            lets.Add(myLetter);
            lets.Add(letterMy);
            Console.WriteLine(lets.Unic());
            // Task 4
            Letter[] letters1 = {myLetter, letterMy };
            var letters = from l in letters1
                          where (l.adressTo.Email == "mom@.com")
                          select l;

            foreach (var l in letters)
                Console.WriteLine(l);

            var len = lets.lets.Capacity;
            var tasks = new Task[3];

            var i = 0;
            Console.WriteLine("Task");
            foreach (var letter in lets.lets)
            {

                tasks[i] = new Task(letter.Read);
                Thread.Sleep(1000);
                tasks[i].Start();
                i++;
            }

        }
    }
}