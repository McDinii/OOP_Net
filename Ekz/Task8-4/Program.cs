using static Program;

public class Program
{
    public interface IScore
    {
        public int Acount { get;set;}
        public void Add(int money);
        public void Take(int money);
    }
    public abstract class Human
    {
        public DateTime birth;
    } 
    public class Person : Human, IScore
    {
        static int count =0;
        static  Person(){
            count+=1;
        }
        public static void Count()
        {
            Console.WriteLine($"Count objs:{count}");
        }

        public override bool Equals(object? obj)
        {
            Person p = obj as Person;
            
            return birth == p.birth;
        }
        public int Acount {get;set;}
        public void Add(int money)
        {
            Acount+=money;
            Console.WriteLine($"U add:{money}$\n Now on ur Account:{Acount}$");
        }
        public void Take(int money)
        {
            Acount += money;

            Console.WriteLine($"U take:{money}$\n Now on ur Account:{Acount}$");
        }
        public override string ToString()
        {
            return $"Account:{Acount}, birthday:{birth}";
           
        }

    }
    public class Bank : List<Person>
    {
        public string name;
        public override string ToString()
        {
            return $"Bank: {name}";

        }
        public string Find(DateTime dt)
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].birth == dt)
                
                return $"{this[i]}";
            }
            return "Doesnt exists";

        }

    }
    
    public static void Main()
    {
        Console.WriteLine("Task1\n");
        var chel1 = new Person {Acount=1000,birth=new DateTime(2003,09,12) };
        var chel2 = new Person {Acount=1500,birth=new DateTime(2005,11,15) };
        var chel3 = new Person {Acount=100,birth=new DateTime(2004,01,02) };
        var chel4 = new Person {Acount=10000,birth=new DateTime(2004,01,02) };
        chel1.Add(100);
        chel2.Take(1000);
        chel3.Add(100);

        Console.WriteLine("Task2\n");
        Console.WriteLine("Task3\n");
       
        Console.WriteLine(chel1.Equals(chel1));
        Console.WriteLine(chel1.Equals(chel2));
        Console.WriteLine(chel1.Equals(chel3));
        Console.WriteLine(chel3.Equals(chel4));
        chel1.Add(100);
        chel2.Take(1000);
        chel3.Add(100);
        Person.Count();
        Console.WriteLine("Task4\n");
        var belarus = new Bank { name="Belarus"};
        var alfa = new Bank { name="Alfa"};
        var vtb = new Bank { name="VTB"};
        belarus.Add(chel1);
        belarus.Add(chel2);
        belarus.Add(chel3);
        alfa.Add(chel1);
        alfa.Add(chel4);
        alfa.Add(chel3);
        vtb.Add(chel4);
        vtb.Add(chel2);
        vtb.Add(chel3);
        var banks = new Bank[] {belarus,alfa,vtb};
        foreach (var b in banks) { 
            Console.WriteLine(b);
            for (int i = 0; i < b.Count; i++)
            {
                Console.WriteLine(b[i]);
            } 
            }
        Console.WriteLine("Task5\n");


        
        
        Task task1 = new Task(() =>Console.WriteLine(belarus.Find(new DateTime(2004, 01, 02))));        
        Task task2 = new Task(() => Console.WriteLine(alfa.Find(new DateTime(2004, 01, 02))));        
        Task task3 = new Task(() => Console.WriteLine(vtb.Find(new DateTime(2003, 01, 02))));        
        task1.Start();
        Thread.Sleep(1000);      
        task2.Start();
        Thread.Sleep(1000);      
        task3.Start();
        Thread.Sleep(1000);


    }
}