using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    public class People
    {
        public string Name;
        public string Profession;

        public People(string name, string profession)
        {
            Name = name;
            Profession = profession;
        }

        public override string ToString()
        {
            return $"name: {Name}\tjob: {Profession}\n";
        }
    }
}
