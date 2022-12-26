using System.Collections.Concurrent;
using System.Diagnostics;

namespace lab15
{
    public class Program
    {
        public static void EratosthenesSieve_1(int n)       // решето Эратосфена
        {
            System.Threading.Thread.Sleep(100);
            var sw = new Stopwatch();
            sw.Start();

            var flags = new bool[n];

            for (var i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
            }

            Console.WriteLine($"All primes up to {n}:  ");
            for (var i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"The algorithm took {sw.ElapsedMilliseconds} ms to execute");
        }

        public static CancellationTokenSource TokenSource = new();
        public static void EratosthenesSieve_2(int n)
        {
            System.Threading.Thread.Sleep(100);
            var sw = new Stopwatch();
            sw.Start();


            var flags = new bool[n];

            for (var i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j; i < n;)
            {
                Console.WriteLine($"The task is in progress #{Task.CurrentId}.");
                System.Threading.Thread.Sleep(1000);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;

                if (TokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("\nPremature stop!");
                    return;
                }
            }

            Console.WriteLine($"All primes up to {n}:  ");
            for (var i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"The algorithm took {sw.ElapsedMilliseconds} ms to execute");
        }

        public static void Main()
        {
            //Task1();//Используя TPL создайте длительную по времени задачу (на основе Task) на выбор:
            //Task2();//Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken
                      //и отмените задачу
            //Task3(); //Создайте три задачи с возвратом результата и используйте их для
                      //выполнения четвертой задачи.Например, расчет по формуле.
            //Task4(); //Создайте задачу продолжения (continuation task) в двух вариантах

            //Task5();//Используя Класс Parallel распараллельте вычисления циклов For(),ForEach().
            
            //Task6();//Используя Parallel.Invoke() распараллельте выполнение блока операторов.
            
            
            Task7();//Используя Класс BlockingCollection реализуйте следующую задачу:
            //Есть 5 поставщиков бытовой техники, они завозят уникальные товары на склад(каждый по одному)
            //и 10 покупателей – покупают все подряд, если товара нет - уходят.В вашей задаче: cпрос превышает
            //предложение.Изначально склад пустой.У каждого поставщика свояскорость завоза товара.
            //Каждый раз при изменении состоянии склада выводите наименования товаров на складе.
            
            //Task8();//Используя async и await организуйте асинхронное выполнение любого метода.
            
        }

        public static void Task1()
        {
            Console.Write("Enter n:");
            var n = Convert.ToInt32(Console.ReadLine());
            var sw = new Stopwatch();
            var task = new Task(() => EratosthenesSieve_1(n));
            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            task.Start();

            while (true)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine($"Task #{task.Id} status - {task.Status}");
                if (task.Status == TaskStatus.RanToCompletion)
                    break;
                
                Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            }
            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
        }

        public static void Task2()
        {
            Console.Write("Enter n:");
            int n;
            n = Convert.ToInt32(Console.ReadLine());

            var task2 = new Task(() => EratosthenesSieve_2(n));
            Console.WriteLine($"Task #{task2.Id} status - {task2.Status}");
            task2.Start();

            Console.WriteLine("\nTo stop the task, press 0:");
            var s = Console.ReadLine();
            if (s == "0")
                TokenSource.Cancel();

            Console.WriteLine($"Task #{task2.Id} status - Completed");
        }

        public static void Task3()
        {
            var rand = new Random();
            var rand1 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 1 + 2; });
            var rand2 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 3 + 4; });
            var rand3 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 5 + 6; });
            rand1.Start(); rand2.Start(); rand3.Start();


            int Sum(int a, int b, int c) { return a + b + c; }

            var result = new Task<int>(() => Sum(rand1.Result, rand2.Result, rand3.Result));
            result.Start();

            Console.WriteLine("Result task3: " + result.Result);
        }

        public static void Task4()
        {
            int Sum(int a, int b) => a + b;
            void Display(int sum) { Console.WriteLine($"Sum: {sum}"); }

            var task1 = new Task<int>(() => Sum(4, 5));

            var task2 = task1.ContinueWith(sum => Display(sum.Result));    //задача с продолжением
            task1.Start();
            Console.Read();
        }

        public static void Task5()
        {
            int Factorial(int x)
            {
                var result = 1;

                for (var i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            }

            var arr1 = new int[10][];
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Parallel.For(0, arr1.Length, i => { arr1[i] = new int[100000]; });
            Parallel.ForEach(list, (a) => Console.WriteLine("factorial of " + a + " " + Factorial(a)));
        }

        public static void Task6()
        {
            Parallel.Invoke
            (
                () => { Thread.Sleep(1000); Console.WriteLine($"The task is in progress {Task.CurrentId}"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"The task is in progress {Task.CurrentId}"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"The task is in progress {Task.CurrentId}"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"The task is in progress {Task.CurrentId}"); Thread.Sleep(3000); },
                () => { Thread.Sleep(1000); Console.WriteLine($"The task is in progress {Task.CurrentId}"); Thread.Sleep(3000); }
            );
        }

        public static void Task7()
        {
            var bc = new BlockingCollection<string>(5);
            var ts = new CancellationTokenSource();

            //sellers
            var sellers = new Task[]
            {
                new(() => { while(true){Thread.Sleep(700); bc.Add("potato"); } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("carrot"); } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("apple");  } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("lemon");  } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("banana"); } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("potato"); } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("carrot"); } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("apple");  } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("lemon");  } }),
                new(() => { while(true){Thread.Sleep(700); bc.Add("banana"); } })
            };

            //consumers
            var consumers = new Task[]
            {
                new(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(300);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
                new(() => { while(true){ Thread.Sleep(350);   bc.Take(); } })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();
            var count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(1000);
                    Console.WriteLine("----------Warehouse----------");

                    foreach (var item in bc)
                        Console.WriteLine(item);

                    Console.WriteLine("-------------------------");
                }
            }
        }

        public static void Task8()
        {
            void Factorial()
            {
                var result = 1;
                for (var i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                Console.WriteLine($"The factorial is equal to {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("The beginning of the method FactorialAsync");
                await Task.Run(Factorial);
                Console.WriteLine("End of method FactorialAsync");
            }

            FactorialAsync();
            Console.WriteLine("main continues its execution");
            Console.ReadKey();
        }
    }
}