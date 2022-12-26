namespace Laba_11
{

    public class Production
    {
        public int Id;
        public string Organization;

        public Production(int id, string organization)
        {
            Id = id;
            Organization = organization;
        }
    }
    public class MiSet : IShow
    {
        public HashSet<string> _set; // обьявили поле типа множество hashset
        private const int MaxLen = 5;
        public Developer? developer; // Поле типа вложенного класса Developer
        public Production? production; // либо null либо значение. Поле внешнего класс Production

        public MiSet(string value) // конструктор со строковым параметром
        {
            _set = new HashSet<string> { value }; // создаем новый экземпляр класса nbg
        }

        public void ProductionInitialization(int id, string organization) // метод создания экземпляра внешнего класса Production 
        {
            production = new Production(id, organization);
        }
        public void Show() // реализация метода интерфейса IShow
        {
            foreach (var item in _set)
            {
                Console.WriteLine(item);
            }
        }
        public void ToConsole(List<string> strList)
        {
            foreach (var str in strList)
            {
                Console.WriteLine(str);
            }
        }
        public class Developer // вложенный класс 
        {
            public string Name; // поля вложенного класса
            public int Id;
            public string Department;

            public Developer(string name, int id, string department) // конструктор с парамертами вложенного класса
            {
                Name = name;
                Id = id;
                Department = department;
            }
        }

        public void DeveloperInitialization(string name, int id, string department) // метод создания экземпляра вложеннго класса Developer
        {
            developer = new Developer(name, id, department);
        }

        public string this[int index] // индексатор без имени
        {
            get
            {
                if (index > (int)this - 1) // int(this) вернет кол-во элементов во множестве тк ниже мы сами перегрузили его 
                                           // проверяем есть ли индекс во мнж 
                    throw new ArgumentOutOfRangeException(); // если нет, ост программу с ошибкой

                var size = 0;
                foreach (var item in _set) // иначе прохдимся циклом по множеству
                {
                    if (size == index) // пока индекс не совпадет 
                        return item;  // выводим Элемент по индексу
                    size++;
                }

                return "";
            }
            set
            {
                if (index > (int)this - 1)  // проверяем есть ли индекс во мнж 
                    throw new ArgumentOutOfRangeException();// если нет, ост программу с ошибкой

                var set = new HashSet<string>(); // создаем новый экзепляр типа HashSet
                var size = 0;

                foreach (var item in _set) // пока item в текущем множестве 
                {
                    set.Add(size == index ? value : item); // если равно переданому индексу, добавляем в set переданное значение value, иначе копируем item из текущего множества  
                    size++;
                }

                _set = set; // заменяем старое мнж на новое с нашим вставвленным элементом 
            }
        }

        public void Print() // вывести множество 
        {
            foreach (var str in _set) // пока элемент во множестве
            {
                Console.WriteLine("value: {0}", str); // , выводим элемент
            }
        }

        #region operators // перегрузка операции для удобства использования
        public static MiSet operator +(MiSet set, string item) // перегрузка +, чтобы добавлять элемент во множество 
        {
            set._set.Add(item); // add встроенный метод добавление во множество
                                // Теперь на + добавляем элемент в множество 
            return set;
        }

        public static MiSet operator +(MiSet set, MiSet set2) // перегрузка +, чтобы конкантинировать множества
        {
            foreach (var e in set2._set) // проходимся по второму мнж
            {
                set += e; // пользуемся ранее перегруженным оператором + (добавление элемента во мнж)
                          // добавляе элементы set2 в set
            }

            return set;
        }

        public static MiSet operator *(MiSet set, MiSet set2) // Перегружаем оператор *, чтобы объединяять множества
        {
            set._set.IntersectWith(set2._set); // объединяем мнж с помощью метода IntersectWith 
            return set; // В нашем классе MiSet само множетсво лежит в поле _set, поэтому получаем мы его такой записью set2._set
        }

        public static explicit operator int(MiSet set) // перегружаем явный оператор int() (используем в индексаторе )
        {
            return set._set.Count; // возвращает кол-во элементов во множестве
        }


        public static bool operator false(MiSet set) // проверка на принадлежность опр диапазону
        {
            return (int)set > MaxLen; // сравниваем мощность множества с ранее заданой длиной MaxLen = 5, если оно больше возвращаем False
        }
        // Тк нельзя перегружать только один Bool оператор, необходимо перегрузить и True 
        public static bool operator true(MiSet set) // проверка на принадлежность опр диапазону
        {
            return (int)set <= MaxLen; // сравниваем мощность множества с ранее заданой длиной MaxLen = 5, если оно меньще или равно возвращаем True
        }
        #endregion
    }

}