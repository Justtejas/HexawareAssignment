namespace Task7_14.Model
{
    internal class Account2
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public Customer AccountHolder { get; set; } 
        public int LastAcc {  get; set; }

        public Account2()
        {
        }

        public Account2(int accountNumber, string accountType, decimal accountBalance, Customer accountHolder)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;
            AccountHolder = accountHolder;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber} \t Account Type: {AccountType} \t Balance: {AccountBalance}";
        }
    }
}
