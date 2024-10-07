namespace Task7_14.Exceptions
{
    internal class OverDraftLimitExceededException:ApplicationException
    {
        public OverDraftLimitExceededException() { }

        public OverDraftLimitExceededException(string message)
            : base(message) { }

        public OverDraftLimitExceededException(string message, Exception inner)
            : base(message, inner) { }
    }
}
