namespace Task7_14.Model
{
    internal class ZeroBalanceAccount:Account2
    {
         public ZeroBalanceAccount(int accountNumber, string accountType, Customer customer)
        : base(accountNumber, accountType, 0, customer) // Initial balance is zero
    {
    }
    }
}
