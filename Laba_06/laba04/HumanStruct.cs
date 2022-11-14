namespace laba05
{
    public class HumanStruct : Human
    {
        public string jobTitle;
        public HumanStruct(string name, DateTime age, string jobTitle) : base(name, age)
        {
            this.jobTitle = jobTitle;
        }

        public HumanStruct(string name, DateTime age, string gender, string jobTitle) : base(name, age, gender)
        {
            this.jobTitle = jobTitle;
        }

        public void Heal()
        {
            if (jobTitle == "doctor")
            {
                Console.WriteLine("HEALTH");
            }
        }
    }
}
