using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Task37
{
    /* [Serializable]
     class Time : IComparable<Time>
     {
         public Time()
         {
             Hours = 0;
             Minutes = 0;
             Seconds = 0;
         }
         public Time(int H, int M, int S)
         {
             Hours = H;
             Minutes = M;
             Seconds = S;
         }
         int hours;
         public int Hours
         {
             get { return hours; }
             set
             {
                 if (value >= 0 && value <= 24) hours = value;
                 else Console.WriteLine("У нас часы от 0-24");
             }
         }
         int minutes;
         public int Minutes
         {
             get { return minutes; }
             set
             {
                 if (value >= 0 && value <= 60) minutes = value;
                 else Console.WriteLine("У нас минуты от 0-60"); minutes = value;
             }
         }
         int seconds;
         public int Seconds
         {
             get { return seconds; }
             set
             {
                 if (value >= 0 && value <= 60) seconds = value;
                 else Console.WriteLine("У нас секунды от 0-60"); seconds = value;
             }
         }

         public void Print()
         {
             Console.WriteLine($"Hours:{Hours},Minutes:{Minutes},Seconds:{Seconds}");

         }
         public override string ToString()
         {
             return $"Hours:{Hours} Minutes:{Minutes} Seconds:{Seconds}";
         }
         public int CompareTo(Time t2)
         {

             if (this.Hours > t2.Hours) return 1;
             if (this.Hours == t2.Hours && this.Minutes == t2.Minutes) return 0;
             if (this.Hours < t2.Hours) return -1;
             else return 0;

         }
     }

     class Program
     {


         static void Main()
         {
             // Task 1
             Time curTime = new Time(7,43,34);
             Time curTime2 = new Time(12, 45, 34);
             Time curTime22 = new Time(12, 45, 34);
             Time curTime222 = new Time(23, 45, 59);
             Time curTime3 = new Time(4, 45, 34);
             Time curTime4 = new Time(15, 45, 34);

             curTime.Print();
             curTime2.Print();

             // Task 2  
             Console.WriteLine((curTime2).CompareTo(curTime2));
             Console.WriteLine((curTime2).CompareTo(curTime22));
             Console.WriteLine((curTime2).CompareTo(curTime222));
             Console.WriteLine((curTime2).CompareTo(curTime3));
             Console.WriteLine((curTime2).CompareTo(curTime4));

             // Task 3 
             using (StreamWriter sw = new StreamWriter("day.txt"))
             {
                 Time[] times = new Time[] { curTime, curTime2, curTime22, curTime222, curTime3, curTime4 };

                 sw.WriteLine("morning");
                 Console.WriteLine("morning");

                 var morning = from t in times
                         where (t.Hours >= 6 && t.Hours <= 12)
                         select t;
                 foreach (var m in morning)
                 {
                     Console.WriteLine(m);
                     sw.WriteLine(m);
                 }
                 sw.WriteLine();
                 Console.WriteLine();
                 sw.WriteLine("afternoon");
                 Console.WriteLine("afternoon");

                 var afternoon = from t in times
                         where (t.Hours >= 13 && t.Hours <= 20)
                         select t;
                 foreach (var a in afternoon)
                 {
                     Console.WriteLine(a);
                     sw.WriteLine(a);
                 }
                 sw.WriteLine();
                 Console.WriteLine();
                 sw.WriteLine("evening");
                 Console.WriteLine("evening");
                 var evening = from t in times
                         where (t.Hours >= 21 && t.Hours <= 24)
                         select t;
                 foreach (var e in evening)
                 {
                     Console.WriteLine(e);
                     sw.WriteLine(e);
                 }
                 sw.WriteLine();
                 Console.WriteLine();
                 var night = from t in times
                             where (t.Hours >= 1 && t.Hours <= 5)
                             select t;
                 sw.WriteLine("night");
                 Console.WriteLine("night");

                 foreach (var n in night)
                 {
                     Console.WriteLine(n);
                     sw.WriteLine(n);
                 }
                 Console.WriteLine();
                 sw.WriteLine();

                 // Task 4
                 var jsonFormat = new DataContractJsonSerializer(typeof(Time[]));
                 using (var file = new FileStream("time.json", FileMode.Create)){
                     jsonFormat.WriteObject(file, times);
                 }
             }
         }
     }*/

    [Serializable]
     public class Time : IComparable<Time>
    {
        public Time(int h,int m,int s)
        {Hours = h;
            Minutes = m;
            Seconds = s;

        }
        int hours;
        [NonSerialized]
        int minutes;
        int seconds;
        public int Hours
        {
            get { return hours; }
            set
            { if (hours >=0 && hours <=24 )
                hours = value;
            else Console.WriteLine("Часы братик, часы");
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (minutes >= 0 && minutes <= 60)
                    minutes = value;
                else Console.WriteLine("Минуты братик");
            }
        }
        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (seconds >= 0 && seconds <= 60)
                    seconds = value;
                else Console.WriteLine("Секунды братик");
            }
        }
        public override string ToString()
        {
            return $"Hours:{Hours}, Minutes:{Minutes}, Seconds:{Seconds}";
        }
        public int CompareTo(Time t)
        {
            if (Hours == t.Hours && Minutes == t.Minutes) return 0;
            if (Hours > t.Hours ) return 1;
            else if (Hours < t.Hours) return -1;
            else return 0;
            
        }
    }

        class Program
    {
        static void Main()
        {
            // Task 1
            Time time = new Time(12,45,54);
            //Time time = new Time(25,62,61); doesnt work because 25 > 24 etc
            // Task 2 
            Time time1 = new Time(13,45,66);
            Time time2 = new Time(18,45,66);
            Time time3 = new Time(11,45,66);
            Time time4 = new Time(23,46,66);
            Time time5 = new Time(4,46,66);
            Console.WriteLine(time.CompareTo(time1));
            Console.WriteLine(time.CompareTo(time2));
            Console.WriteLine(time.CompareTo(time3));
            Console.WriteLine(time.CompareTo(time4));

            // Task 3 
            Time[] times = {time,time1, time2, time3,time4, time5 };
            using ( StreamWriter file = new StreamWriter("file.txt")) { 
            var morning = from t in times
                          where (t.Hours >=6 && t.Hours <=12)
                          select t;
            file.WriteLine("morning");
            foreach (var k in morning)
                     file.WriteLine(k);
            file.WriteLine();
                var day = from t in times
                              where (t.Hours >= 13 && t.Hours <= 20)
                              select t;
                file.WriteLine("day");
                foreach (var k in day)
                    file.WriteLine(k);
                file.WriteLine();
                var even = from t in times
                              where (t.Hours >= 21 && t.Hours <= 24)
                              select t;
                file.WriteLine("evening");
                foreach (var k in even)
                    file.WriteLine(k);
                file.WriteLine();
                var night = from t in times
                              where (t.Hours >= 1 && t.Hours <= 5)
                              select t;
                file.WriteLine("night");
                foreach (var k in night)
                    file.WriteLine(k);
                file.WriteLine();


            }
            // Task 4
            var jsonF = new DataContractJsonSerializer(typeof(Time[]));
            using(var filejson = new FileStream("filejson.json", FileMode.OpenOrCreate))
            {
                jsonF.WriteObject(filejson,times);
            }

        }
    }
}