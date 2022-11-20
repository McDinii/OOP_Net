using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_07
{
    public sealed class Transformer : IntelligentBeing, ITransport
    {
        private readonly Engine _heart;
        private double _energy;
        private bool _transformationStatus;
        private const double EnergyСonsumption = 5.5;

        public int Power => _heart.Power;

        public double Energy
        {
            get => _energy;
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("energy can't be negative");
                }

                _energy = value;
            }

        }

        public Transformer(Engine engine, string name, DateTime age, double energy) : base(name, age)
        {
            _heart = engine;
            Energy = energy;
            _transformationStatus = false;
        }
        public Transformer(int power, string name, DateTime age, double energy) : base(name, age)
        {
            _heart = new Engine(power);
            Energy = energy;
            _transformationStatus = false;
        }

        public void Transformation()
        {
            _transformationStatus = !_transformationStatus;
        }

        public void Launch()
        {
            Console.WriteLine("launch");
            _heart.Status = true;
        }

        public void Shutdown()
        {
            Console.WriteLine("shutdown");
            _heart.Status = false;
        }

        public bool ReadinessСheck()
        {
            return _heart.Status && Energy > 0;
        }

        public void Drive()
        {
            if (ReadinessСheck())
            {
                Console.WriteLine("drive");
                Energy -= EnergyСonsumption / 100;
            }
        }

        public void SpeedControl()
        {
            if (_transformationStatus)
            {
                Console.WriteLine(_heart.Power * 24);
            }
            else
            {
                Console.WriteLine("Parking");
            }
        }

        public override string ToString()
        {
            return $"transformer {Name} was created {Age} years ago";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Transformer transformer)
            {
                if (transformer.Name == Name && transformer.Age == Age && Math.Abs(transformer.Energy - Energy) < 0.001
                    && transformer._heart == _heart && transformer._transformationStatus == _transformationStatus)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Energy.GetHashCode() + _heart.GetHashCode() +
                   _transformationStatus.GetHashCode();
        }
    }
}
