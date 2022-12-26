
using Laba_09;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Laba_09
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task 1
            var ITech = new Product();
            ITech.Add("Iphone 14", "$799.00");
            ITech.Add("Iphone 13", "$599.00");
            ITech.Add("AirPods 3", "$169.00");
            ITech.Add("AirPods Pro", "$249.00");
            ITech.Add("MacBook Air", "$999.00");
            ITech.Add("MacBook Pro 14”", "$1999.00");

            Console.WriteLine("\n\tList all Products: ");
            foreach (string i in ITech.Keys)
                Console.WriteLine(i);

            Console.WriteLine("\n\tList all price:");
            foreach (string i in ITech.Values)
                Console.WriteLine(i);

            Console.WriteLine("\n\tPrice Iphone 14?");
            Console.WriteLine(ITech["Iphone 14"]);

            ITech.Remove("AirPods 3");
            Console.WriteLine("\n\tList product after delete AirPods 3");
            foreach (string i in ITech.Keys)
                Console.WriteLine(i);

            var accessories = new Product();
            accessories.Add("iPhone 14 Silicone Case", "$49.00");
            accessories.Add("MagSafe Charger", "$39.00");
            accessories.Add("20W USB-C Power Adapter", "$19.00");
            accessories.Add("Magic Keyboard Folio for iPad", "$249.00");

            var IStore = new ConcurrentBag<Product>();
            IStore.Add(ITech);
            IStore.Add(accessories);

            Console.WriteLine("\n\tAll product from IStore:  ");
            foreach (var IProducts in IStore)
            {
                foreach (var IProduct in IProducts.Keys)
                    Console.WriteLine(IProduct);
            }

            // Task 2 

            var bag = new ConcurrentBag<int>();

            for (var i = 0; i < 20; i++)
            {
                bag.Add(i);
            }

            Console.WriteLine("\n\tElements first collection before changes:");

            foreach (var a in bag)
            {
                Console.WriteLine(a);
            }

            int n;
            for (var i = 0; i < 4; i++)
            {
                bag.TryTake(out n);
                Console.WriteLine(n);
            }

            Console.WriteLine("\n\tElements first collection after changes:");
            foreach (var a in bag)
            {
                Console.WriteLine(a);
            }

            // create second collection

            var list = new List<int>();

            while (!bag.IsEmpty)
            {
                if (bag.TryTake(out n))
                {
                    list.Add(n);
                }
            }

            Console.WriteLine("\nelements of the second collection:");
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(list.Contains(11) ? "\nbag2 contains '11'" : "\nbag2 no contains '11'\n");


            // Task 3
            var MyColletion = new ObservableCollection<Product>();

            MyColletion.CollectionChanged += MyCollection_onChange; // подписываемся на изменения коллекции 

            MyColletion.Add(ITech);
            MyColletion[0] = accessories;
            MyColletion.RemoveAt(0);
        }

        private static void MyCollection_onChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Add element in collection MyCollection");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Delete element in collection MyCollection");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Change element in collection MyCollection");
                    break;
            }
        }
    }
}