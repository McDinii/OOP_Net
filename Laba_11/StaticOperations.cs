using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    static class StaticOperation // ниже методы расширения
    {
        public static int Max(this MiSet set) // This необходим для расширения типа, к которому у нас нет доступа
        {

            return set._set.Select(item => item.Length).Max(); // Операция Select используется для создания выходной последовательности
                                                               // одного типа элементов из входной последовательности элементов другого типа
        }
        public static int Min(this MiSet set)
        {
            return set._set.Select(item => item.Length).Max(); // возвращаем минимальный элемент
        }

        public static int Difference(this MiSet set)
        {
            return Max(set) - Min(set);
        }

        public static int CountItem(this MiSet set)
        {

            return set._set.Count();
        }

        public static void AddComma(this MiSet set)
        {
            var size = (int)set; // мощность множества
            var newSet = new HashSet<string>();
            for (int i = 0; i < size; i++)
            {
                newSet.Add(set[i] + ",");
            }
            set._set = newSet;

        }
        public static void Distinct(this MiSet set)
        {
            set._set = set._set.Distinct().ToHashSet();
        }
    }
}
