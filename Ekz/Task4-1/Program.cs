class Program
{
    public interface IAirable
    {
        public string Fly();
        public string Check();

    }
    public interface IAirHostess
    {
        public void Check();

    }
    public abstract class Transport
    {
        public int Cost;

    }
    public enum Status
    {
        fly,
        ready,
        stop
    }

    public class Air:Transport, IAirable, IAirHostess
    {
     
        public int Speed { get;set;}
        public int CountOfPassangers { get;set;}
        public Status stat = Status.stop;

        public string Fly()
        {
            if(stat == Status.fly)
            return"I'm flying";
            else throw new Exception("Ты пидор");

        }

        void IAirHostess.Check()
        {
            if(CountOfPassangers <= 100 && CountOfPassangers >=20 ) { 
         
                Console.WriteLine("ready"); }
        }
        public string Check()
        {
            if (stat == Status.ready && Speed > 0 && CountOfPassangers > 0) { 
                stat=Status.fly;
                return "I'm flying"; }
            else if(Speed == 0 && CountOfPassangers == 0) { 
                stat = Status.ready;
                return"I'm ready"; }
            else return "Good";

            
        }
        public override string ToString()
        {
            return $"Cost:{Cost},Speed:{Speed},Status:{stat}";
        }
    }

    public static void Main()
    {
        using (StreamWriter sw = new StreamWriter("file.txt"))
        {
            var air = new Air {Cost=100,Speed=300, CountOfPassangers=21,stat=Status.fly};
        var air2 = new Air {Cost=1000,Speed=0, CountOfPassangers=0,stat=Status.stop };
        var air3 = new Air {Cost=100,Speed=300, CountOfPassangers=10,stat=Status.ready };
        var air4 = new Air {Cost=100,Speed=300, CountOfPassangers=10,stat=Status.ready };
        var air5 = new Air {Cost=100,Speed=300, CountOfPassangers=10,stat=Status.ready };
       
        try { 
         sw.WriteLine("Task1");
         sw.WriteLine("Task2");
         sw.WriteLine("Task3");

        sw.WriteLine(air.Fly());
        sw.WriteLine(air2.Fly());
        sw.WriteLine(air3.Fly());
        
        sw.WriteLine(air.Check());
        sw.WriteLine(air2.Check());
        sw.WriteLine(air3.Check());
         }
        catch(Exception e) { sw.WriteLine(e.Message);
            } 
        Console.WriteLine(air.Check());
       ((IAirHostess)air).Check();

           var airs = new Air[]  {air,air2,air3,air4,air5}; 
        var flying = from a in airs
                 where a.stat == Status.fly
                 select a;
         var avg = (from a in airs
                
                 select a.Speed).Average(); 
            foreach ( var i in flying)
                sw.WriteLine(i);
                sw.WriteLine(avg);

        }  
        

        // task 4 
    }
}