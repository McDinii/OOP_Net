namespace laba05
{
    public sealed partial class Transformer : IntelligentBeing, ITransport
    {

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
            return Age.GetHashCode();
        }
    }
}
