using laba06;

namespace laba05
{
    public class Human : IntelligentBeing
    {
        public string? Gender;

        public Human(string name, DateTime age) : base(name, age) { }

        public Human(string name, DateTime age, string gender) : base(name, age)
        {
            gender = gender.ToLower();
            if (gender != "boy" || gender != "girl")
            {
                throw new InvalidGenderException("we support only two genders a boy and a girl", gender);
            }
            Gender = gender;
        }

        public override string ToString()
        {
            return $"name:{Name}\t age:{Age}\t gender:{Gender}";
        }
    }
}
