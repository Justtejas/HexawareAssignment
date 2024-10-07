namespace Task7_14.Model
{
    internal class CurrentAccount: BankAccount
    {
        public decimal OverdraftLimit = 500m;
        public CurrentAccount
            ()
        { }
        public CurrentAccount(int accNum, decimal balance) : base()
        {
            AccountNumber = accNum;
            Balance = balance;
        }
        public override void Deposit(float amount)
        {
            Balance = Balance + (decimal)amount;
            Console.WriteLine($"Deposited {amount}, New Balance = {Balance}");
        }
        public override void Withdraw(float amount)
        {
            if(Balance + OverdraftLimit >= (decimal)amount)
            {
                Balance -= (decimal)amount;
            }
            else
            {
                Console.WriteLine("Overdraft Limit Exceeded");
            }
        }
        public override void CalculateInterest()
        {
            Console.WriteLine("Current Account does not have Interest");
        }
    }
}
