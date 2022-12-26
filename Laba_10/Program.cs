
using System.Xml.Linq;

namespace Laba_10
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\t\t\t 1 TASK\n");
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var selectedMonthN = from m in month
                                 where m.Length == 7
                                 select m;
            Console.WriteLine("Month len 7:");
            foreach (var str in selectedMonthN)
            {
                Console.Write(str + ",  ");
            }

            var selectedMonthWinSum = from m in month
                                      where Array.IndexOf(month, m) < 2 ||
                                            Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8 ||
                                            Array.IndexOf(month, m) == 11
                                      select m;

            Console.WriteLine("\n\nWinter and summer months:");
            foreach (var str in selectedMonthWinSum)
            {
                Console.Write(str + ",  ");
            }

            var selectedMonthAlfa = from m in month
                                    orderby m
                                    select m;
            Console.WriteLine("\n\nMonth by alphabet:");
            foreach (var str in selectedMonthAlfa)
            {
                Console.Write(str + ",  ");
            }

            var selectedMonthU4 = from m in month
                                  where m.Contains('u') && m.Length > 3
                                  select m;
            Console.WriteLine("\n\nMonths with letter 'u', len >= 4:");
            foreach (var str in selectedMonthU4)
            {
                Console.Write(str + ",  ");
            }


            Console.WriteLine("\n\n\t\t\t 2 TASK\n");

            var studentList = new List<Student>();
            var student1 = new Student("Vanya", "Akmen", "Stepanov",
                new DateTime(2004, 6, 16), "Minsk", "+375298467778",
                "fit", 2, 3);
            studentList.Add(student1);
            var student2 = new Student("Katya", "Vasilieva", "Aleksandrovna",
                new DateTime(2004, 7, 16), "Minsk", "+375298467778",
                "fit", 2, 3);
            studentList.Add(student2);
            var student3 = new Student("Gosha", "Kolechkov", "Aleksandrovnich",
                new DateTime(2004, 8, 16), "Minsk", "+375298467778",
                "fit", 2, 3);
            studentList.Add(student3);
            var student4 = new Student("Denis", "Drugakov", "Dmitrievich",
                new DateTime(2005, 5, 16), "Minsk", "+375298467778",
                "fit", 2, 3);
            studentList.Add(student4);
            var student5 = new Student("Kirill", "Drach", "Arturovich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "fit", 2, 3);
            studentList.Add(student5);
            var student6 = new Student("Kirill", "Kuchinski", "Stepanopich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "htit", 2, 4);
            studentList.Add(student6);
            var student7 = new Student("Maksim", "Sedanov", "Stepanopich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "htit", 2, 3);
            studentList.Add(student7);
            var student8 = new Student("Maksim", "Samkevich", "Timofeevich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "htit", 2, 4);
            studentList.Add(student8);
            var student9 = new Student("Maksim", "Dvorovenko", "Heorhiyovich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "htit", 2, 4);
            studentList.Add(student9);
            var student10 = new Student("Gosha", "Dudar", "Heorhiyovich",
                new DateTime(2004, 9, 16), "Minsk", "+375298467778",
                "pim", 2, 3);
            studentList.Add(student10);

            foreach (var student in studentList)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n\n\t\t\t 3 TASK\n");

            var orderedSelectedStudent = from s in studentList
                                         where s.Faculty == "fit"
                                         orderby s.Name
                                         select s;
            Console.WriteLine("Students from FIT faculty:");
            foreach (var student in orderedSelectedStudent)
            {
                Console.WriteLine(student);
            }

            var SelectedStudent = from s in studentList
                                  where s.Faculty == "htit" && s.Course == 2
                                  select s;
            Console.WriteLine("\n\nStudents from HTIT faculty, 2 course:");
            foreach (var student in SelectedStudent)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine($"\n\nYoungest student:{studentList.First(x => x.Birthday == studentList.Max(y => y.Birthday))}");
            Console.WriteLine($"\n\nCount students in group 3:{studentList.Count(x => x.Group == 3)}");
            Console.WriteLine($"\n\nFirst students with name Maksim:{studentList.First(x => x.Name == "Maksim")}");


            Console.WriteLine("\n\n\t\t\t 4 TASK\n");

            var myLiStudents = from s in studentList
                               where s.Faculty == "fit"
                               orderby s.Name descending
                               select s;

            foreach (var student in myLiStudents)
            {
                Console.WriteLine(student);
            }


            Console.WriteLine("\n\n\t\t\t 5 TASK\n");

            var profList = new List<Profession>();
            var prof1 = new Profession("fit", "Programmer");
            var prof2 = new Profession("htit", "chemist");
            profList.Add(prof1);
            profList.Add(prof2);

            var futurePeople = from s in studentList
                               join p in profList on s.Faculty equals p.Faculty
                               select new People(s.Name, p.Job);

            foreach (var people in futurePeople)
            {
                Console.WriteLine(people);
            }
        }
    }

}