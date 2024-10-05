namespace Insurance_Management_System.Model
{
    internal class Policy
    {
        public int PolicyID { get; set; }
        public string? PolicyNumber { get; set; }
        public string? PolicyType { get; set; }
        public double AmountCovered { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Policy()
        {
            
        }

        public Policy(int policyID, string policyNumber, string policyType, double amountCovered, DateOnly startDate, DateOnly endDate)
        {
            PolicyID = policyID;
            PolicyNumber = policyNumber;
            PolicyType = policyType;
            AmountCovered = amountCovered;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"PolicyId: {PolicyID}\tPolicy Number: {PolicyNumber}\tPolicy Type: {PolicyType}\tAmount Covered: {AmountCovered}\tStart Date: {StartDate}\tEnd Date: {EndDate}";
        }
    }
}
