namespace Laba_07
{

    public class MiSet<T> : ISeteable<T> where T : class // where T: class - ограничение типа
    {
        public HashSet<T> _set; // хэш-таблица

        public T val = default(T);

        public MiSet(T val)
        {
            _set = new HashSet<T> { val };
        }

        public void Add(T item)
        {
            _set.Add(item);
        }

        public void Remove(T item)
        {
            _set.Remove(item);
        }

        public void View()
        {
            foreach (var item in _set)
            {
                Console.WriteLine("val:" + item);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > (int)this - 1 || index < 0)
                    throw new ArgumentOutOfRangeException();

                var size = 0;
                foreach (var item in _set)
                {
                    if (size == index)
                        return item;
                    size++;
                }

                return default(T);
            }
            set
            {
                
                 if (index > (int)this - 1 || index < 0)
                        throw new ArgumentOutOfRangeException();
                 var set = new HashSet<T>();
                    var size = 0;
                    foreach (var item in _set)
                    {
                        set.Add(size == index ? value : item);
                        size++;
                    }
                _set = set;
            }
        }

        public static MiSet<T> operator +(MiSet<T> set, T item)
        {
            set._set.Add(item);
            return set;
        }
        public static MiSet<T> operator +(MiSet<T> set1, MiSet<T> set2)
        {
            foreach (var e in set2._set)
            {
                set1 += e;
            }
            return set1;
        }

        public static MiSet<T> operator *(MiSet<T> set1, MiSet<T> set2)
        {
            set1._set.IntersectWith(set2._set);
            return set1;
        }

        public static implicit operator int(MiSet<T> set)
        {
            return set._set.Count;
        }


        public static bool operator true(MiSet<T> set)
        {
            return (int)set > MaxLen;
        }
        public static bool operator false(MiSet<T> set)
        {
            return (int)set <= MaxLen;
        }
    
         // обьявили поле типа множество hashset
        private const int MaxLen = 5;

        public static void WriteToFile(ref MiSet<T> set)
        {
            using (var sw = new StreamWriter("MiSet.txt"))
            {
                foreach (var item in set._set)
                {
                    sw.WriteLine(item+"\n");
                }
            }
        }
        public static void ReadFromFile()
        {
            using (var file = new StreamReader("MiSet.txt"))
            {
                Console.WriteLine(file.ReadToEnd());
            }
        }


    }

}