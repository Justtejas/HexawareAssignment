namespace Task7_14.Exceptions
{
    internal class InsufficientFundException:ApplicationException
    {
        public InsufficientFundException() { }

        public InsufficientFundException(string message)
            : base(message) { }

        public InsufficientFundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
