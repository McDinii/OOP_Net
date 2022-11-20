namespace Laba08
{
    public class Director
    {
        public int Salary;
        public string Position;

        public delegate void Fine(Director obj, int salary);
        public delegate void Increase(Director obj, int salary, string position);
        public event Fine fine;
        public event Increase? increase;

        public Director(int salary, string position)
        {
            Salary = salary;
            Position = position;
        }

        public void Action(int salary, string position)
        {
            Console.WriteLine(ToString());
            Console.Write("Object Changes: ");

            if (fine != null)
            {
                fine.Invoke(this, salary);
            }
            else
            {
                Console.Write("Salary has not been changed. ");
            }

            if (increase != null)
            {
                increase(this, salary, position);
            }
            else
            {
                Console.Write("The position has not been changed. ");
            }

            Console.WriteLine();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Current parameters of the object: salary = {Salary}, post = {Position}";
        }
    }
}
