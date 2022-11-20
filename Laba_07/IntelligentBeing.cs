using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_07
{
    public abstract class IntelligentBeing : object
    {
        public string Name;

        protected IntelligentBeing(string name, DateTime birthday)
        {
            Name = name;
            _birthday = birthday;
        }

        private readonly DateTime _birthday;
        public TimeSpan Age => DateTime.Now.Subtract(_birthday) / 365;


        public override string ToString()
        {
            return $"this creature:{Name}\t live:{Age} year";
        }
    }
}
