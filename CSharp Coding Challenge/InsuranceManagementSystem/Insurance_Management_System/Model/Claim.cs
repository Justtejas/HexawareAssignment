namespace Insurance_Management_System.Model
{
    internal class Claim
    {
        public int ClaimID { get; set; }
        public int ClaimNumber { get; set; }
        public DateOnly DateFiled { get; set; }
        public double ClaimAmount { get; set; }
        public int PolicyID { get; set; }
        public int ClientID { get; set; }
        public Claim()
        {
            
        }

        public Claim(int claimID, int claimNumber, DateOnly dateFiled, double claimAmount, int policyID, int clientID)
        {
            ClaimID = claimID;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            PolicyID = policyID;
            ClientID = clientID;
        }

        public override string ToString()
        {
            return $"ClaimID : {ClaimID}\t Claim Number: {ClaimNumber}\t Date Filed: {DateFiled}\t Claim Amount: {ClaimAmount}\t PolicyID: {PolicyID}\t ClientID: {ClientID}";
        }
    }
}
