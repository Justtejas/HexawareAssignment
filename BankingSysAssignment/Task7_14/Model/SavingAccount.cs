namespace Task7_14.Model
{
    internal class SavingAccount:BankAccount
    {
        readonly decimal InterestRate = 0.045m;
        public SavingAccount():base(){ }
        public SavingAccount(int accNum, decimal balance) : base()
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
            decimal amnt = Convert.ToDecimal(amount);
            if (Balance > 0 && amnt < Balance)
            {
                Balance -= amnt;
                Console.WriteLine($"Withdrew {amnt}, New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public override void CalculateInterest()
        {
            Console.WriteLine($"The Interest is {Balance * InterestRate}");
        }
    }
} 