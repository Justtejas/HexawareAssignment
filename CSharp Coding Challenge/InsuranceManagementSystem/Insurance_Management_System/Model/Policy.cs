namespace Insurance_Management_System.Model
{
    internal class Policy
    {
        public int PolicyID { get; set; }
        public string? PolicyNumber { get; set; }
        public string? PolicyType { get; set; }
        public double AmountCovered { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy()
        {
            
        }

        public Policy(int policyID, string policyNumber, string policyType, double amountCovered, DateTime startDate, DateTime endDate)
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
