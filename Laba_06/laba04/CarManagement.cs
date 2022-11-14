namespace laba05
{
    public abstract class CarManagement : TransportVehicle
    {
        public string? Model;
        public Engine? Engine;
        public double Weight;
        public double FuelСonsumption => Engine.Power * 10 / Weight;
        private int _transmission;
        public int Transmission
        {
            get => _transmission;
            set
            {
                _transmission = value;

                if (value is < -1 or > 6)
                {
                    Console.WriteLine("you car no support {0} transmission", value);
                    _transmission = 0;
                }
            }
        }
        public int Mileage;

        public abstract void SpeedControl();
        public virtual bool ReadinessСheck()
        {
            return Engine.Status;
        }

        protected CarManagement(int countPassengers, string? model, Engine engine, double weight) : base(countPassengers)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Transmission = 0;
        }

        public override string ToString()
        {
            return $"model: {Model}\t millage:{Mileage} \t weight{Weight}";
        }
    }
}