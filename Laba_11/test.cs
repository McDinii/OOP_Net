using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    public class Test : IShow
    {
        public string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Test() { }

        public Test(string name)
        {
            Name = name;
        }

        public void Show()
        {
            Console.WriteLine(name);
        }

        public void ToConsole(List<string> strList)
        {
            foreach (var str in strList)
            {
                Console.WriteLine(str);
            }
        }

        public override string ToString()
        {
            return "My name - " + name;
        }
    }
}
