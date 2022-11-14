using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_05
{
    public struct HumanStruct
    {
        public string JobTitle;
        public string Name;
        public DateTime Age = DateTime.Now;

        public HumanStruct() : this("JO", new DateTime(2004, 12, 12), "doctor")
        {
        }

        public HumanStruct(string name, DateTime age, string jobTitle)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
        }

        /*public HumanStruct()                   //error\\
        {
            JobTitle = "q231";
        }*/

        public static void Heal()
        {
            Console.WriteLine("dwadw");
            /*if (JobTitle == "doctor")
            {
                Console.WriteLine("HEALTH");
            }*/
        }
    }
}
