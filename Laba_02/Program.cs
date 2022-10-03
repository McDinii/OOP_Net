//Создать класс Student: id, Фамилия, Имя, Отчество,
//Дата рождения, Адрес, Телефон, Факультет, Курс,
//Группа. Свойства и конструкторы должны обеспечивать
//проверку корректности. Добавить метод расчет возраста
//студента
// Создать массив объектов. Вывести:
//a) список студентов заданного факультета;
//d) список учебной группы.
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;


namespace Laba_02 {
    partial class Student {
        public Student()
        {
            Id = id.GetHashCode();
            id++;
            Faculty = "";
            Name = "Student " + id;
            Midname = " ";
            Firstname = "";
            Email = "";
            PhoneNumber = "";
            Group = 1;
            E_year = 1;

        }
    }
    partial class Student
    {
        public static int id;
        public readonly int Id; // поле только для чтения
        // private Student() { } закрытый конструктор
        static Student() { id = 0; } // статический конструктор
        // public Student() { };
        
        public Student(string name, string midname, string firstname, int e_year, string email,
            string phoneNumber, int group, DateTime date_of_birth, string faculty) {
            Id = id.GetHashCode();
            id++;
            this.Name = name;    
            this.Midname = midname;    
            this.Firstname = firstname;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Group = group;                                                                                                                                                                                                                                         
            this.Date_of_birth = date_of_birth;
            this.e_year = e_year;  
            this.Faculty = faculty;

        }
        
        public string Firstname { get; set; }
        private string name;
        public string Name{ get { 
                return name; 
            }
            set
            {
                name = value;
            }
        }
  
        public string Midname { get; set; }
        public string Faculty { get;private set;
        }
        
        int e_year;
        public int E_year
        {
            get
            {
                
                return e_year;
                }
            set
            {
                var val = Convert.ToInt32(value);
                if (val > 0 && val <= 4)
                {
                    e_year =val;
                }
                else
                {
                    throw new ArgumentException("Error ");
                }
            }
        }
        int Group { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date_of_birth { get; set; } 
        const int Cur_year = 2022; // поле константа 
        DateTime DTnow = DateTime.Today;
        public void PrintAll()
        {
            Console.WriteLine($"Student id-{ this.Id}");
            Console.WriteLine($"Student FCs: {this.Name} {this.Midname} {this.Firstname}");
        }
        public static void StudentId(Student student)
        {
            Console.WriteLine($"Student id = {student.Id}");
           
        }
        public void ReturnStudAge() // метод расчета возраста студента
        {
            DateTime dbir = this.Date_of_birth;
            int age = DTnow.Year - dbir.Year;
            if (dbir > DTnow.AddYears(-age)) age--;
            if ( dbir < DTnow)
            {
                Console.WriteLine($"Student {this.name} {this.Firstname} age = {age}");
            }
            
        }
        public override bool Equals(object obj)                 //переопределение метода Equals()
        {
            Student temp = obj as Student;
            if (temp == null)
                return false;
            return (temp.Name == this.Name && temp.Midname == this.Midname && temp.Firstname == this.Firstname && temp.Date_of_birth == this.Date_of_birth);
        }
        public override int GetHashCode()                       //переопределение метода GetHashCode()
        {
            Console.WriteLine("Вызвался переопределенный метод GetHashCode");
            return base.GetHashCode();
        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Имя студента: {this.Name} {this.Firstname}, День рождения: {this.Date_of_birth}, Номер группы: {this.Group}, Курс: {this.E_year}");
        }

        public static void sort_by_fac(Student[] arr, string fc)                  //статический метод вывода информации
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Faculty.Equals(fc))
                {
                    Console.WriteLine($"Имя студента: {arr[i].Name} {arr[i].Firstname}, День рождения: {arr[i].Date_of_birth}, Номер группы: {arr[i].Group}, Курс: {arr[i].E_year}");
                  
                }
            }
        }

        public static void sort_by_gr(Student[] arr, ref int gr)         //статический метод вывода информации + используем параметр ref (передаём параметр по ссылке)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Group == gr)            
                {
                    Console.WriteLine($"Имя студента: {arr[i].Name} {arr[i].Firstname}, День рождения: {arr[i].Date_of_birth}, Номер группы: {arr[i].Group}, Курс: {arr[i].E_year}");
                }
            }
        }
    }
    class Program {
        static void Main() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Student Student_1 = new Student();
            Student Student_2 = new Student("Denis","Nechay","Nitsevich",2,"denisnechay@gmail.com",
                "+375293354677",7,new DateTime(2003,12,09), "FIT");
            Student Student_4 = new Student("Denis", "Nechay", "Nitsevich", 2, "denisnechay@gmail.com",
                "+375293354677", 7, new DateTime(2003, 12, 09), "FIT");
            Student_1.Firstname = "Nechay";
            Student_1.E_year = 4;
            Student_1.Midname = "nitsevich";
           
            Student.StudentId(Student_1);
            Student.StudentId(Student_2);
            Student_2.ReturnStudAge();
            Student Student_3 = new Student();
            Student_3.Name = "Pavel";
            Console.WriteLine(Student_3.Name);
            Console.WriteLine("Проверяем два объекта на равенство:");
            if (Student_2.Equals(Student_3))                  //сравнение объектов
                Console.WriteLine("Равны\n");
            else
                Console.WriteLine("Не равны\n"); 
            if (Student_2.Equals(Student_2))                  //сравнение объектов
                Console.WriteLine("Равны\n");
            else
                Console.WriteLine("Не равны\n");

            Console.WriteLine("Определяем тип:\n" + Student_2.GetType() + "\n");      //определение типа


            var an_student = new { Name = "Anonimus" };
            Student[] stds = new Student[7] {
                new Student("Denis","Nechay","Egorovich",2,"denisnechay@gmail.com","+375293354677",7,new DateTime(2003,12,09), "FIT"),
                new Student("Pavel","Pudel","Vasyvich",2,"pavel@gmail.com","+375293454677",7,new DateTime(2002,12,09), "FIT"),
                new Student("Ira","Kudel","Petyavna",2,"ira@gmail.com","+375293354655",7,new DateTime(2003,05,09), "FIT"),
                new Student("Kira","Ilin","Niksevna",2,"kira@gmail.com","+375293354666",7,new DateTime(2003,04,09), "FIT"),
                new Student("Petya","Volikov","Nikitich",2,"volik@gmail.com","+375293354688",7,new DateTime(2002,12,08), "NEFIT"),
                new Student("Vasya","Petrob","Temorich",2,"vpetrob@gmail.com","+375293354699",7,new DateTime(2002,12,19), "FIT"),
                new Student("Denis","Pavlov","Viktoriich",2,"denispavlov@gmail.com","+375293354611",7,new DateTime(2004,11,09), "NEFIT"),
                                                    };

            Console.WriteLine("Сортировка по группе:\n");
            int needed_gr = 7;
            Student.sort_by_gr(stds, ref needed_gr); //передаём параметр по ссылке
            Console.WriteLine("\n");
            Console.WriteLine("Сортировка по фак:\n");
            Student.sort_by_fac(stds, "FIT");
  
        }
    }
}