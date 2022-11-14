using laba06;

namespace laba05
{
    public sealed partial class Transformer
    {
        private readonly Engine _heart;
        private double _energy;
        private bool _transformationStatus;
        private const double EnergyСonsumption = 5.5;
        public EnumTypesOfTransformers Type;

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

        public Transformer(Engine engine, string name, DateTime age, double energy, EnumTypesOfTransformers type) : base(name, age)
        {
            _heart = engine;
            Energy = energy;
            if ((int)type < 0 || (int)type > 3)
            {
                throw new InvalidTypeException("invalid type", (int)type);
            }
            Type = type;
            _transformationStatus = false;
        }
        public Transformer(int power, string name, DateTime age, double energy, EnumTypesOfTransformers type, bool _transformationStatus = false) : base(name, age)
        {
            _heart = new Engine(power);
            Energy = energy;
            Type = type;

            if ((int)type < 0 || (int)type > 3)
            {
                throw new InvalidTypeException("invalid type", (int)type);
            }

            _transformationStatus = false;
        }
    }
}
