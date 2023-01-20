using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
public  class Program
{
    public interface INumber
    {
        public int Number { get; set; }

    }

    [Serializable]
    public class Bill : INumber
    {
        [NonSerialized]
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                    throw new Exception("Must be positive");
                else if (value == 10 || value == 20 || value == 50 || value == 100)
                {
                    number = value;
                }
                else throw new Exception("Must be 10,20,50,100");
            }

        }
        public override string ToString()
        {
            return $"Number:{Number}";
        }
        

    }

    [Serializable]
    public class Wallet<T> where T: Bill
    {
       public  List<Bill> bills = new List<Bill>();
        public void Add(Bill b)
        {
            int sum = 0;
            foreach (var i in bills)
                sum += i.Number;
            if (sum > 100)
            {
                throw new Exception("MuchMOney");
                var min = (from bb in bills
                           select bb).Min();
                bills.Remove(min);
            }
            bills.Add(b);
        }
        public void Remove(Bill b)
        {
            if (bills.Count == 0)
            {
                throw new Exception("NotToDeleteFromWallet");
            }
            bills.Remove(b);

        }
        public override string ToString()
        {
            var st = "";
            foreach ( var i in bills)
                st += i.ToString() + ", ";
            return st;
        }
    }
    public static void Main()
    {
        try
        {

            var b1 = new Bill { Number = 100 };
            var bb1 = new Bill { Number = 20 };
            var bbb1 = new Bill { Number = 20 };
            //  var bbbb = new Bill { Number = 0 };
            var wall1 = new Wallet<Bill> { };
            wall1.Add(b1);
            wall1.Add(bb1);
            //  wall.Remove(b);
            //wall.Add(bbb);
            //  wall.Remove(b);
           
            var bil = new[] { 10, 20, 50, 100 };
            foreach (var c in bil)
            {
                var kolvo = (from w in wall1.bills
                             where w.Number == c
                             select w.Number).Count();
                Console.WriteLine($"{c}:{kolvo}");
            }
            

        }
        catch (Exception e) { Console.WriteLine($"Error:{e.Message}"); }
        var b = new Bill { Number = 100 };
        var bb = new Bill { Number = 20 };
        var bbb = new Bill { Number = 20 };

        var wall = new Wallet<Bill> { };
        wall.Add(b);
       
        var js = new XmlSerializer(typeof(Wallet<Bill>));
        using (var file = new FileStream("file.xml", FileMode.OpenOrCreate))
        {
            js.Serialize(file, wall);
        }
    }
}