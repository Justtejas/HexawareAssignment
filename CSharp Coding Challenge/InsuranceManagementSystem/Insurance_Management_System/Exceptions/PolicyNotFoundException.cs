namespace Insurance_Management_System.Exceptions
{
    internal class PolicyNotFoundException:Exception
    {
        public int PolicyID { get; }

        public PolicyNotFoundException() { }

        public PolicyNotFoundException(string message)
            : base(message) { }

        public PolicyNotFoundException(string message, int policyID)
            : this(message)
        {
            PolicyID = policyID;
        }
    }
}
