namespace laba05
{
    public class Engine
    {
        public string? Model;
        public int Power;
        public bool Status;

        public Engine(string? model, int power)
        {
            Model = model;
            Power = power;
            Status = false;
        }

        public Engine(int power)
        {
            Model = "undefended";
            Power = power;
            Status = false;
        }

        public override string ToString()
        {
            return $"engine model:{Model} with power{Power}";
        }
    }
}
