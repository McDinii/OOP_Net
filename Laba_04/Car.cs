using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba_04
{
    public class Car : CarControl, ITransport
    {
        public void Launch()
        {
            Console.WriteLine("launch");
            Engine.Status = true;
        }

        public void Shutdown()
        {
            Console.WriteLine("shutdown");
            Engine.Status = false;
        }

        private double _fuel;
        public double Fuel
        {
            get => _fuel;
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("fuel can't be negative");
                }

                _fuel = value;
            }
        }

        void ITransport.SpeedControl()
        {
            Console.WriteLine("interface don't support Speed control");
        }
        public override void SpeedControl()
        {
            if (Transmission == 0)
            {
                Console.WriteLine("Parking");
            }
            else
            {
                Console.WriteLine(Engine.Power * Transmission * 13.5);
            }
        }

        public override bool ReadinessСheck()
        {
            return Engine.Status && Fuel > 0;
        }

        public void Drive()
        {
            if (ReadinessСheck())
            {
                Console.WriteLine("drive");
                Fuel -= FuelСonsumption / 100;
                Mileage++;
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        public Car(int countPassengers, string? model, Engine engine, double weight, double fuel)
            : base(countPassengers, model, engine, weight)
        {
            Fuel = fuel;
            Transmission = 0;
        }

        public override string ToString()
        {
            return $"car model:{Model}\t power:{Engine.Power}\t fuel:{Fuel}";
        }
    }
}
