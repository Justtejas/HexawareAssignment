namespace Insurance_Management_System.Model
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public DateOnly PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public int ClientID { get; set; }
        public Payment()
        {
            
        }

        public Payment(int paymentID, DateOnly paymentDate, double paymentAmount, int clientID)
        {
            PaymentID = paymentID;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            ClientID = clientID;
        }

        public override string ToString()
        {
            return $"PaymentID: {PaymentID}\tPayment Date: {PaymentDate}\tPayment Amount: {PaymentAmount}\tClientID: {ClientID}";
        }
    }
}
