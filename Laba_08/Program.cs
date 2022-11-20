namespace Laba08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var d1 = new Director(3000, "director");
            var d2 = new Director(4500, "director");
            var d3 = new Director(5000, "director");
            var ce = new Event();

            d1.fine += ce.DoFine;
            d1.increase += ce.DoIncrease;
            d2.fine += ce.DoFine;

            d1.Action(7000, "financial director");
            Console.WriteLine("----------------------------------------");
            d2.Action(4700, "director");
            Console.WriteLine("----------------------------------------");
            d3.Action(5000, "director");
            var str = "I.   S- i?  T b-e,s t#3";
            
            Func<string, string> a;
            
            Console.WriteLine("--------------Working with strings--------------");
            a = Str.RemoveS;
            Console.WriteLine($"Without punctuation marks:\nBefore: {str}\nAfter: {a(str)}\n");
            a = Str.RemoveSpase;
            Console.WriteLine($"Remove spaces:\nBefore: {str}\nAfter: {a(str)}\n");
            a = Str.Upper;
            Console.WriteLine($"Capital letters:\nBefore: {str}\nAfter: {a(str)}\n");
            a = Str.Letter;
            Console.WriteLine($"Uppercase letters:\nBefore: {str}\nAfter: {a(str)}\n");
            a = Str.AddToString;
            Console.WriteLine($"Adding characters:\nBefore: {str}\nAfter: {a(str)}\n");
        }
    }
}