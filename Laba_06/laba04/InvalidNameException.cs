namespace laba06;

class InvalidNameException : ArgumentException
{
    public string Value { get; }
    public InvalidNameException(string message, string name) : base(message)
    {
        Value = name;
        Data.Add("Time Exception", DateTime.Now);
    }
}