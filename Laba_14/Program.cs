using Laba_14;
using System.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        //лаба была спижена
        First();
        Second();
        Third();
        Fourth();
        Fifth();
    }


    // Задание 1. Определите и выведите на консоль/в файл все запущенные процессы: id, имя, приоритет, время запуска, текущее состояние,
    // сколько всего времени использовал процессор и т.д..

    private static void First()
    {
        var allProcesses = Process.GetProcesses();        // получаем массив со всеми процессами
        Console.WriteLine("Information about processes:");
        Console.Write("{0,-20}", "ID:");
        Console.Write("{0,-70}", "Process Name:");
        Console.Write("{0,-20}", "Priority:\n");
        foreach (var process in allProcesses)
        {
            Console.Write("{0,-20}", $"{process.Id}");
            Console.Write("{0,-70}", $"{process.ProcessName}");
            Console.Write("{0,-20}", $"{process.BasePriority}");
            Console.WriteLine();
        }
    }



    // Задание 2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки, загруженные в домен.
    //Создайте новый домен. Загрузите туда сборку. Выгрузите домен.

    private static void Second()
    {
        var domain = AppDomain.CurrentDomain;                   // текущий домен с процессами
        Console.WriteLine("Information about current domain:");
        Console.WriteLine("\n\nCurrent domain:\t" + domain.FriendlyName);
        Console.WriteLine("Base directory:\t" + domain.BaseDirectory);
        Console.WriteLine("Configuration Details:\t" + domain.SetupInformation);
        Console.WriteLine("All assemblies in the domain:\n");

        foreach (var assembly in domain.GetAssemblies())
        {
            Console.WriteLine(assembly.GetName().Name);
        }

        //устарело
        //AppDomain newDomain = AppDomain.CreateDomain("New Domain"); // создание нового домена
        //newDomain.Load(Assembly.GetExecutingAssembly().FullName);   // загрузка сборки
        //AppDomain.Unload(newDomain);                                // выгрузка домена + всех содержащихся в нём сборок
    }



    /* Задание 3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для задержки) записи
     * на консоль простых чисел от 1 до n (задает пользователь). Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.).
     * Во время выполнения выведите информацию о статусе потока, имени, приоритете, числовой идентификатор и т.д. */

    private static void Third()
    {
        Mutex mutex = new Mutex();  // позволяет обеспечить синхронизацию среди множества процессов.
                                    // Только один поток может получить блокировку и иметь доступ к синхронизированным областям кода.
        Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));   // создаем новый поток
        NumbersThread.Start(7);                                                       // запускаем его

        Thread.Sleep(2000);         // приостанавливает выполнение потока, в котором он был вызван
        mutex.WaitOne();            // ожидает до тех пор, пока не будет получен мьютекс, для которого он был вызван (вход в критическую секцию)

        Console.WriteLine("\n--------------------");
        Console.WriteLine("Priority:   " + NumbersThread.Priority);
        Thread.Sleep(100);
        Console.WriteLine("Name tread:  " + NumbersThread.Name);
        Thread.Sleep(100);
        Console.WriteLine("ID tread:   " + NumbersThread.ManagedThreadId);
        Console.WriteLine("---------------------");
        Thread.Sleep(1000);

        mutex.ReleaseMutex();       // освобождение мьютекса потоком, выход из критической секции
        Thread.Sleep(2000);         // приостанавливает выполнение потока, в котором он был вызван

        void WriteNums(object number)   // ввод чисел 
        {
            int num = (int)number;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
    }



    /* Задание 4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и
    записывают их в на консоль.
    a. Поменяйте приоритет одного из потоков.
    b. Используя средства синхронизации организуйте работу потоков, таким образом,
    чтобы:
            i. выводились сначала четные, потом нечетные числа
            ii. последовательно выводились одно четное, другое нечетное. */

    private static void Fourth()
    {
        Console.WriteLine("\n\n\nthead evan and odd numbers");
        Thread evenThread = new Thread(Methods.EvenNumbers);        // поток чётных чисел
        evenThread.Priority = ThreadPriority.Normal;           // меняем приоритет по заданию
        evenThread.Start();                 // если закомментить Join(), второй поток не будет ждать первый
        evenThread.Join();                  // чтобы выводились поочередно, надо закомментить эту строку

        Console.WriteLine();
        Thread oddThread = new Thread(Methods.OddNumbers);          // поток нечётных чисел
        oddThread.Priority = ThreadPriority.Normal;
        oddThread.Start();
        oddThread.Join();                  // дожидаемся завершение работы потока
        Console.WriteLine("\n");
    }



    /* Задание 5. Придумайте и реализуйте повторяющуюся задачу на основе класса Timer */

    private static void Fifth()
    {
        TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);  // делегат для таймера

        // позволяет запускать определенные действия по истечению некоторого периода времени:
        Timer timer = new Timer(timerCallback, null, 500, 1000);       /* null - параметр, которого нет, 500 - время, через которое запустится процесс с таймером, 
                                                                            * 1000 - периодичность таймера (интервал между вызовами метода делегата). */
        Thread.Sleep(5000);                                             // 500 - ждем и не закрываем поток
        timer.Change(Timeout.Infinite, 2000);                           // уничтожение таймера

        void WhatTimeIsIt(object obj)
        {
            Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
        }
        Console.ReadLine();
        Console.ReadLine();
    }
}