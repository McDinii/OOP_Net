using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_04
{
    public class Human : IntelligentBeing // наследуем
    {
        public string? Gender; 

        public Human(string name, DateTime age) : base(name, age) { }

        public Human(string name, DateTime age, string gender) : base(name, age)
        {
            Gender = gender;
        }

        public override string ToString()
        {
            return $"name:{Name}\t age:{Age}\t gender:{Gender}";
        }
    }
}
