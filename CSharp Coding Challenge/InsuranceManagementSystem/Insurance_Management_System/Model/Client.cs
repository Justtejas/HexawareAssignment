namespace Insurance_Management_System.Model
{
    internal class Client
    {
        public int ClientID { get; set; }
        public string? ClientName { get; set; }
        public string? ContactInfo { get; set; }
        public int PolicyID { get; set; }
        public Client()
        {
            
        }

        public Client(int clientID, string clientName, string contactInfo,int policyID)
        {
            ClientID = clientID;
            ClientName = clientName;
            ContactInfo = contactInfo;
            PolicyID = policyID;
        }

        public override string ToString()
        {
            return $"ClientID: {ClientID}\tClient Name: {ClientName}\tContact Info: {ContactInfo}\tPolicy ID: {PolicyID}";
        }
    }
}
