using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_04
{
    public class Engine
    {
        public string? Model;
        public int Power;
        public bool Status;

        public Engine(string? model, int power) // конструктор 
        {
            Model = model;
            Power = power;
            Status = false;
        }

        public Engine(int power) // конструктор 
        {
            Model = "undefended";
            Power = power;
            Status = false;
        }

        public override string ToString() // переопределяем метод 
        {
            return $"engine model:{Model} with power{Power}";
        }
    }
}
