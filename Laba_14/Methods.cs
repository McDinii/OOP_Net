using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_14
{
    class Methods
    {
        public static void EvenNumbers()        // вывод чётных чисел до 20
        {
            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }

        public static void OddNumbers()         // вывод нечётных чисел до 20
        {
            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
