namespace Task7_14.Model
{
    internal class Account
    {
        readonly decimal InterestRate = 0.045m;
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        public Account() { }

        public Account(int accountNumber, string accType, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountType = accType;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber} \t Account Type: {AccountType} \t Balance: {Balance}";
        }

        public void Deposit(float amount)
        {
            Balance = Balance + (decimal) amount;
            Console.WriteLine($"Deposited {amount}, New Balance = {Balance}");
        }

        public void Deposit(int amount)
        {
            Balance = Balance + (decimal) amount;
            Console.WriteLine($"Deposited {amount}, New Balance = {Balance}");
        }
        public void Deposit(double amount)
        {
            Balance = Balance + (decimal) amount;
            Console.WriteLine($"Deposited {amount}, New Balance = {Balance}");
        }
        public virtual void Withdraw(float amount)
        {
            decimal amnt = Convert.ToDecimal(amount);
            if (Balance > 0 && amnt < Balance)
            {
                Balance -= amnt;
                Console.WriteLine($"Withdrew {amnt}, New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Could not withdraw");
            }
        }
        public virtual void Withdraw(int amount)
        {
            decimal amnt = Convert.ToDecimal(amount);
            if (Balance > 0 && amnt < Balance)
            {
                Balance -= amnt;
                Console.WriteLine($"Withdrew {amnt}, New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Could not withdraw");
            }
        }
        public virtual void Withdraw(double amount)
        {
            decimal amnt = Convert.ToDecimal(amount);
            if (Balance > 0 && amnt < Balance)
            {
                Balance -= amnt;
                Console.WriteLine($"Withdrew {amnt}, New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("Could not withdraw");
            }
        }
        public virtual void CalculateInterest()
        {
            Console.WriteLine($"Interest is {Balance * InterestRate}");
        }

        public static implicit operator Account(SavingAccount v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Account(CurrentAccount v)
        {
            throw new NotImplementedException();
        }
    }
}
