namespace Task7_14.Model
{
    internal class SavingAccount2: Account2
    {
        public decimal InterestRate { get; set; }

        public const decimal MIN_BALANCE = 500;

        public SavingAccount2(int accountNumber, string accountType, decimal initialBalance, Customer customer, decimal interestRate)
        : base(accountNumber, accountType, initialBalance, customer)
        {
            if (initialBalance < MIN_BALANCE)
            {
                throw new ArgumentException($"Initial balance cannot be less than {MIN_BALANCE:C} for a savings account.");
            }
            InterestRate = interestRate;
        }

        public void CalculateInterest()
        {
            Console.WriteLine($"Interest is { AccountBalance * InterestRate / 100}");
        }
    }
}
