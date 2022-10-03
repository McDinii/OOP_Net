using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

internal class Program
{


    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        // task 1
        // A
        int age = 10;
        char animal = 'd';
        float weight = 16.7F;
        double speed = 11.56;
        bool flag = true;
        byte storage = 255;
        decimal lenght = 1.454353m;
        short height = -1234;
        long number = 23634632656;
        Console.WriteLine("Task 1A\n  Int = {0} \n Char = {1} \n Float = {2} Double = {3} \n Bool {4} \n Byte = {5} \n Decimal = {6} \n Short = {7} \n Long = {8}",
            age, animal, weight, speed, flag, storage, lenght, height, number);
        // B
        age = Convert.ToInt32(age);
        Console.WriteLine("Task 1B\n" + age + "\n");
        number = (short)number;
        flag = Convert.ToBoolean(height);
        Console.WriteLine("short ---> bool, now sh = " + height);
        age = Convert.ToInt32(flag);
        Console.WriteLine("type of i {0}", age.GetType());
        weight = 1.232423f;
        speed = weight; // float -> double (1) 
        storage = 8;
        number = storage; // byte -> short (2)
        age = height; // short -> int (3)  
        number = age;// int -> long (4)
        double width = age; // int -> double (5)
        // C
        int age_2 = 123;
        object obj = age;
        Console.WriteLine("Task 1C\n" + obj.GetType());
        Console.WriteLine(age_2.GetType());
        Console.WriteLine((int)obj);
        Console.WriteLine(obj.GetType());
        Console.WriteLine(String.Concat("Answer", 42, true));
        // D
        var val = 1234;
        Console.WriteLine("Task 1D\nType of v = " + val.GetType());
        // E 
        int? notInt = null;
        Console.WriteLine("Task 1E\nType of notInt = " + val.GetType());
        // F 
        var taskF = 345;
        // taskF = "notInt";

        // Task 2
        // 2a 
        string name = "Denis";
        string midName = "Nechay";
        string copyname = "Denis";
        Console.WriteLine("Task 2a");
        Console.WriteLine("Compare:" + String.Compare(name, midName));
        Console.WriteLine("Equals:" + String.Equals(name, midName));
        Console.WriteLine("Contains:" + name.Contains(midName));
        Console.WriteLine("Compare:" + String.Compare(name, copyname));
        Console.WriteLine("Equals:" + String.Equals(name, copyname));
        Console.WriteLine("Contains:" + name.Contains(copyname));
        Console.WriteLine("== " + name == copyname);
        Console.WriteLine("== " + name == midName);

        // 2b 
        Console.WriteLine("2b\n");
        string str1 = "Hello";
        string nameD = " Denis";
        string deal = "How are you doing Denis?";
        Console.WriteLine("2b Сцепление: " + String.Concat(str1, nameD));
        Console.WriteLine("Копирование: str1 = " + str1 + " Copy = " + String.Copy(str1));
        Console.WriteLine("Подстрока: str1 = " + str1 + " Substring[:4] = " + str1.Substring(4));
        string[] subs = deal.Split(" ");
        foreach (var sub in subs)
        {
            Console.WriteLine(" Разеделение строки deal = " + deal + $" Разделение: {sub}");
        }
        str1 = str1.Insert(1, " eee ");
        Console.WriteLine("Insert " + str1.Insert(1, " eee "));
        Console.WriteLine("Remove " + str1.Remove(1, 5));
        // 2c 
        Console.WriteLine("2c\n");
        string empty = string.Empty;
        string nullStr = null;
        if (string.IsNullOrWhiteSpace(empty))
        {
            Console.WriteLine("i am Empty ");
        }
        if (string.IsNullOrEmpty(nullStr))
        {
            Console.WriteLine("I am Null ");
        }
        // 2d 
        Console.WriteLine("2d\n");
        StringBuilder sb = new StringBuilder("hi dear R2D2", 50);

        Console.WriteLine("Sb = " + sb);
        sb.Remove(0, 7);
        Console.WriteLine("Sb After rm " + sb);
        sb.Insert(5, " & C3PO");
        Console.WriteLine("Sb After insert " + sb);
        sb.Append(": Star Wars");
        Console.WriteLine("Sb After Append " + sb);

        // 3 Arrays
        // 3a
        var len = 4;
        var wid = 3;
        int[,] arr = new int[len, wid];

        Console.WriteLine("3a");
        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < wid; j++)
            {
                arr[i, j] = i + j;
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
        int[] nums = { 1, 3, 5, 7, 9 };
        string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        Console.WriteLine("3b string arr: " + string.Join(",", weekDays2));
        Console.WriteLine("Lenght of massive: " + weekDays2.Length);
        Console.WriteLine("3c\n");
        int[][] jaggedArr = new int[3][];
        jaggedArr[0] = new int[2];
        jaggedArr[1] = new int[3];
        jaggedArr[2] = new int[4];


        for (int i = 0; i < jaggedArr.Length; i++)
        {
            for (int j = 0; j < jaggedArr[i].Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    Console.WriteLine("Enter number");

                    jaggedArr[0][0] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Your arr\\/");
                    Console.Write(jaggedArr[0][0] + " ");
                }
                else
                {
                    jaggedArr[i][j] = i + j;
                    Console.Write(jaggedArr[i][j] + " ");
                }
            }
            Console.WriteLine();
        }
        // 3d
        var strArr = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        Console.WriteLine("Our array");
        for (int i = 0; i < strArr.Length; i++)
        {
            Console.Write($"StrArr[{i}]:");
            Console.WriteLine(strArr[i]);
        }
        var strWeek = "Sun, Mon, Tue, Wed, Thu, Fri, Sat";
        Console.WriteLine("Our string" + strWeek);
        // 4a
        Console.WriteLine("4a,b");
        (int, string, char, string, ulong) tup = (7, "hi", 'g', "ih", 1844674407370955161);
        Console.WriteLine($"tup: {tup}");
        Console.WriteLine($"int: {tup.Item1},string: {tup.Item2},char: {tup.Item3},string: {tup.Item4},ulong: {tup.Item5}");
        Console.WriteLine("4c");
        (var age2, var height2, _) = (12, 34, "hello");
        (var age3, _, _, _, _) = tup;
        Console.WriteLine($"tup {tup}");
        (int, string, ulong) tup1 = (6, "hello", 22352523232332);
        Console.WriteLine($"age2 = {age2},height2 = {height2}");
        Console.WriteLine($"age3 = {age3}");
        var tup1_1 = tup1;
        Console.WriteLine($"tup1_1 = {tup1_1}");
        Console.WriteLine($"tup == tup1: {tup1 == tup1_1}"); // if dim not equal we cant compare             

        //  5
        int limit = 0;
        //local function
        (int, int, int, char) Tupler(int[] num, string str)
        {
            int max_num = -2147483648;
            int min_num = 2147483647;
            int sum = 0;
            for (int i = 0; i < num.Length; i++) {

                max_num = Math.Max(max_num, num[i]);
                min_num = Math.Min(min_num, num[i]);
                sum += num[i];
            }
            (int, int, int, char) tup = (max_num, min_num, sum, str[0]);
            return tup;
        }
        int[] arr_5 = {-1, 0, 1, 2, 3, 4, 7};
        string car = "Porsche";
        Console.WriteLine($"task 5\n Parametrs [-1, 0, 1, 2, 3, 4, 7] and {car} fun return :{Tupler(arr_5,car)}");
        //6
        void check_fun()
        {
            double a = double.MaxValue;

            int b;

            try
            {
                b = ((int)a + 1 );
            }
            catch (OverflowException e)
            {
                Console.WriteLine("checked: double -> int "+e.Message);  // output: Arithmetic operation resulted in an overflow.
            }
        }
        void uncheck_fun()
        {
            double a = double.MaxValue;
            int b = unchecked((int)a);
            Console.WriteLine("unchecked: double-> int "+b);  // output: -2147483648
        }
        check_fun();
        uncheck_fun();

    }
}