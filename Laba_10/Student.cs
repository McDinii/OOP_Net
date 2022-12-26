using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    public class Student
    {
        public static int _idCounter;
        public const string University = "BSTU";
        private readonly int Id;
        public string Name { get; set; }
        public string LastName { get; }
        private string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        private string City { get; set; }

        private string PhoneNumber { get; set; }
        public string Faculty { get; set; } = "";

        public int Course { get; set; }
        public int Group { get; set; }
        public int AgeСalculation()
        {
            var now = DateTime.Today;
            var age = now.Year - Birthday.Year;
            if (Birthday > now.AddYears(-age)) age--;
            return age;
        }

        public static List<Student> FacultyList(List<Student> students, string faculty)
        {
            return students
                .Where(student => student.Faculty == faculty)
                .ToList();
        }

        public static List<Student> FacultyAndGroupList(List<Student> students, string faculty, int group)
        {
            return students
                .Where(student => student.Faculty == faculty && student.Group == group)
                .ToList();
        }

        public void CourseRemained(out int count, ref int countCourse)
        {
            countCourse = Faculty.ToLower() == "fit" ? 4 : 5;
            count = countCourse - Course;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student student)
            {
                if (student.Name == Name && student.LastName == LastName
                    && student.MiddleName == MiddleName && student.Birthday == Birthday
                    && student.City == City && student.PhoneNumber == PhoneNumber
                    && student.Faculty == Faculty && student.Course == Course && student.Group == Group)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"student({Id}):\t Name: {Name}\t LastName: {LastName}\t MiddleName: {MiddleName}\t" +
                   $"Birthday: {Birthday}\nCity: {City}\t PhoneNumber: {PhoneNumber}\t Faculty: {Faculty}\t" +
                   $"Course: {Course}\t Group: {Group}\n";
        }

        static Student()
        {
            _idCounter = 0;
        }

        private Student()
        {
        }

        public Student(string name, string lastName, DateTime date, string phoneNumber, string faculty)
        {
            Faculty = faculty;
            PhoneNumber = phoneNumber;
            Birthday = date;
            LastName = lastName;
            Name = name;
            Id = _idCounter.GetHashCode();
            _idCounter++;
        }

        public Student(string phoneNumber, string faculty, string name = "unknown", string lastName = "unknown",
            string middleName = "unknown", string city = "unknown")
        {
            Birthday = DateTime.Now;
            Faculty = faculty;
            PhoneNumber = phoneNumber;
            City = city;
            MiddleName = middleName;
            LastName = lastName;
            Name = name;
            Id = _idCounter.GetHashCode();
            _idCounter++;
        }

        public Student(string name, string lastName, string middleName,
            DateTime date, string city, string phoneNumber, string faculty,
            int course, int group)
        {
            Group = group;
            Course = course;
            Faculty = faculty;
            PhoneNumber = phoneNumber;
            City = city;
            Birthday = date;
            MiddleName = middleName;
            LastName = lastName;
            Name = name;
            Id = _idCounter.GetHashCode();
            _idCounter++;
        }
    }
}
