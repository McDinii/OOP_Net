using System;

class Program
{
    public abstract class Function
    {
        public virtual int Func()
        {
            Console.WriteLine("Func");
            return X;
        }
        public int X { get;set;}

    }
    public class Liner : Function
    {
        public int A {get;set; }
        public int B {get;set; }
        public override int Func()
        {
            Console.WriteLine($"Liner:{A * X + B}");
            return A*X+B;
        }
        public override string ToString()
        {
            return $"Liner:{A * X + B}";
        }
        public override bool Equals(object? obj)
        {
            Liner f = obj as Liner;
            return A == f.A && B == f.B && X == f.X;
        }
    }
    public class Sqr : Function
    {
        public int A {get;set; }
        public int B {get;set; }
        public int C {get;set; }
        public override int Func()
        {
            Console.WriteLine($"Sqr:{A * (X * X) + B * X + C}");
            return A * (X*X) + B*X +C;
        }
        public override string ToString()
        {
            return $"Sqr:{A * (X * X) + B * X + C}";
        }
        public override bool Equals(object? obj)
        {
            Sqr f = obj as Sqr;
            return A == f.A && B == f.B && C == f.C && X == f.X;
        }
    }
    public class ArrayFunct<T>
    {
       public  T[] arr;
        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        
        public override string ToString()
        {
    
            string st = "";
            for(var i = 0;i<arr.Length;i++)
               st+= $"{arr[i]}, ";
            return st;
       
        }

    }
    public static void Main()
    {
        using ( StreamWriter file = new StreamWriter("file.txt")) { 
       Console.WriteLine("Task1");
       file.WriteLine("Task1");
        var func1 = new Liner {A=5,B=6,X=2 };
        var func2 = new Liner {A=-4,B=10,X=1 };
        var func3 = new Sqr {A=-4,B=10,C=3,X=2 };
        var func4 = new Sqr {A=-4,B=10,C=2,X=1 };
       Console.WriteLine("Task2");
       file.WriteLine("Task2");
        Function[] arr2 = new Function[] { func1,func2,func3,func4}; 
        var arr = new ArrayFunct<Function> { arr=arr2 };
       Console.WriteLine(arr);
       file.WriteLine(arr);
       Console.WriteLine("Task3");
       file.WriteLine("Task3");
        for(int i = 0; i < arr.arr.Length; i++) { 
            arr[i].Func();
            file.WriteLine($"{arr[i].Func()}"); }

       Console.WriteLine("Task4");
       file.WriteLine("Task4");
        var  f = (from a in arr2
                  select a.Func()).Min();


         file.WriteLine(f);
         file.WriteLine("Task5");
    
        }
       
    }
}