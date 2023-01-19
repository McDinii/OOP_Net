using System.Collections;
using System.Collections.Generic;

public class Program
{
    public class Item
    {
        public string Name { get;set;}
        public int ID { get;set;}
        public double Price { get;set;}


        public override bool Equals(object? obj)
        {
            Item it = obj as Item;
            return Name == it.Name && Price==it.Price;
        } 
        public override string ToString()
        {
            return $"Name:{Name}, Price:{Price}";
        }
        public void Reduce()
        {
            Console.WriteLine($"Before:{this}\n");
            Price = Price*0.5;
            Console.WriteLine($"After:{this}\n");
        }
    }
    public class Shop: IEnumerable
    {
        public Queue<Item> clothes = new Queue<Item>();
        public void Add(Item obj)
        {
            clothes.Enqueue(obj);
        }
        public void Del(Item obj)
        {
           
            var ne = new Queue<Item>();
            foreach (var i in clothes)
            {
                if (!i.Equals(obj))
                {
                    ne.Enqueue(i);
                }
            }
            clothes = ne;
            


        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            
            return clothes.GetEnumerator();
        }
        public void Clear()
        {
            clothes.Clear();
        }
        public static Shop operator +(Shop sh,Item cl)
        {
            sh.Add(cl);
            return sh;
            
        }
        public static Shop operator -(Shop sh,Item cl)
        {
            sh.Del(cl);
            return sh;
        } }
    
    public class Manager
        {
            
            public delegate void Scale();
            public event Scale Sale;
            public void Scal()
            { 
              if( Sale != null){
                Sale();
                     }
              

            }

        }
    public static void Main()
    {
      // Task1/
        // Task2
        var item = new Item {Name="Car",ID=1,Price=1000.5 };
        var item2 = new Item {Name="Phone",ID=2,Price=105.5 };
        var item3 = new Item {Name="Book",ID=3,Price=45.5 };

        var shop = new Shop();
        shop.Add(item);
        shop.Add(item2);
        shop.Add(item3);
        Console.WriteLine(item);
        Console.WriteLine(item2);
        Console.WriteLine(item3);
        
        foreach (var i in shop)
        {
            Console.WriteLine(i);
        }
        // Task 3 
        Console.WriteLine("Task3");
        shop-=item3;
        foreach (var i in shop)
            Console.WriteLine(i);
        // Task 4 
        var man = new Manager();
        man.Sale += item.Reduce;
        man.Sale += item2.Reduce;
        man.Scal();
        foreach ( var i in shop)
            Console.WriteLine(i);

        var clot = new Item[] {item,item2,item3};
        var its = (from s in clot
                  where (s.Name == "Car")
                  select s.Price).Sum();
       Console.WriteLine($"Sum:{its}");
        

    }
}