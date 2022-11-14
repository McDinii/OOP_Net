namespace laba06
{
    class InvalidTypeException : ArgumentException
    {
        public int Value { get; }
        public InvalidTypeException(string message, int type) : base(message)
        {
            Value = type;
            Data.Add("Time exception", DateTime.Now);
        }
    }
}
