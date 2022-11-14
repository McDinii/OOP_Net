namespace laba06;

class InvalidGenderException : InvalidNameException
{
    public InvalidGenderException(string message, string name)
        : base(message, name)
    {
        Data.Add("Tme Exception", DateTime.Now);
    }
}