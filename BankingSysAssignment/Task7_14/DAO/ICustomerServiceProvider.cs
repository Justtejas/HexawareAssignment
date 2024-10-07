namespace Task7_14.DAO
{
    internal interface ICustomerServiceProvider
    {
        decimal GetAccountBalance(int accountNumber);
        decimal Deposit(int accountNumber, decimal amount);
        decimal Withdraw(int accountNumber, decimal amount);
        bool Transfer(int fromAccountNumber, int toAccountNumber, decimal amount);
        string GetAccountDetails(int accountNumber);
    }
}
