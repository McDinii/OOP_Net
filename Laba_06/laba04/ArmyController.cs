namespace laba05
{
    public class ArmyController
    {
        public void FoundByDate(Army army, DateTime date)
        {
            foreach (var being in army.List.Where(being => being.Birthday.Equals(date)))
            {
                switch (being)
                {
                    case Human:
                        Console.WriteLine($"Found human with name: {being.Name} and birthday: {date}");
                        break;
                    case Transformer:
                        Console.WriteLine($"Found transformer with name: {being.Name} and birthday: {date}");
                        break;
                }
            }
        }

        public void FoundTransformerByPower(Army army, int power)
        {
            foreach (var transformer in army.List.Where(being => being is Transformer))
            {
                if (((Transformer)transformer).Power == power)
                {
                    Console.WriteLine($"Found transformer with name: {transformer.Name} and power: {power}");
                }
            }
        }

        public void ArmyCount(Army army)
        {
            Console.WriteLine($"Army count: {army.List.Count}");
        }
    }
}
