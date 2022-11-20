namespace Laba08
{
    public class Event
    {
        public void DoFine(Director obj, int salary)
        {
            obj.Salary = salary;
            Console.Write($"New salary of the director = {salary}. ");
        }

        public void DoIncrease(Director obj, int salary, string position)
        {
            obj.Salary = salary;
            obj.Position = position;
            Console.Write($"New salary and position = {salary}\t{position}");
        }
    }
}
