namespace Task7_14.Model
{
    internal abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }

        public BankAccount() { }

        public BankAccount(int accNum, string custName, decimal balance)
        {
            AccountNumber = accNum;
            CustomerName = custName;
            Balance = balance;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber} \t Customer Name: {CustomerName} \t Balance: {Balance}";
        }
        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void CalculateInterest();

    }
}
