using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_05
{
    public class Army
    {
        private List<IntelligentBeing> _list;

        public Army()
        {
            _list = new List<IntelligentBeing>();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public List<IntelligentBeing> List
        {
            get => _list;
            set
            {
                if (value is List<IntelligentBeing>)
                {
                    _list = value;
                }
            }
        }

        public void Add(object value)
        {
            if (value is IntelligentBeing being)
            {
                _list.Add(being);
            }
        }

        public void Remove(object value)
        {
            if (value is IntelligentBeing being)
            {
                _list.Remove(being);
            }
        }

        public void Print()
        {
            foreach (var being in _list)
            {
                switch (being)
                {
                    case Human:
                        Console.WriteLine($"Human with name: {being.Name}");
                        break;
                    case Transformer:
                        Console.WriteLine($"Transformer with name: {being.Name}");
                        break;
                    default:
                        Console.WriteLine($"Transformer with name: {being.Name}");
                        break;
                }
            }
        }
    }
}
