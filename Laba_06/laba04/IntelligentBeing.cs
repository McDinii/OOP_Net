using laba06;

namespace laba05
{
    public class IntelligentBeing : object
    {
        public string Name;


        public readonly DateTime Birthday;
        public TimeSpan Age => DateTime.Now.Subtract(Birthday) / 365;

        public IntelligentBeing(string name, DateTime birthday)
        {
            if (name.Contains('%'))
            {
                throw new InvalidNameException("you have an invalid character", name);
            }

            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"this creature:{Name}\t live:{Age} year";
        }
    }
}
