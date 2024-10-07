using Task7_14.Model;

namespace Task7_14.DAO
{
    internal class CustomerServiceProviderImp:ICustomerServiceProvider
    {
        private Dictionary<int, Account2> accounts = new();

        public decimal GetAccountBalance(int accountNumber)
        {
            if (accounts.TryGetValue(accountNumber, out Account2 account))
            {
                return account.AccountBalance;
            }
            throw new KeyNotFoundException("Account not found.");
        }

        public decimal Deposit(int accountNumber, decimal amount)
        {
            if (accounts.TryGetValue(accountNumber, out Account2 account))
            {
                account.AccountBalance += amount;
                return account.AccountBalance;
            }
            throw new KeyNotFoundException("Account not found.");
        }

        public decimal Withdraw(int accountNumber, decimal amount)
        {
            if (accounts.TryGetValue(accountNumber, out Account2 account))
            {
                account.AccountBalance -= amount;
                return account.AccountBalance;
            }
            throw new KeyNotFoundException("Account not found.");
        }

        public bool Transfer(int fromAccountNumber, int toAccountNumber, decimal amount)
        {
            if (accounts.TryGetValue(fromAccountNumber, out Account2 fromAccount) &&
                accounts.TryGetValue(toAccountNumber, out Account2 toAccount))
            {
                Withdraw(fromAccountNumber, amount);
                Deposit(toAccountNumber, amount);
                return true;
            }
            throw new KeyNotFoundException("One or both accounts not found.");
        }

        public string GetAccountDetails(int accountNumber)
        {
            if (accounts.TryGetValue(accountNumber, out Account2 account))
            {
                return account.ToString();
            }
            throw new KeyNotFoundException("Account not found.");
        }

        public void AddAccount(Account2 account)
        {
            accounts[account.AccountNumber] = account;
        }
    }
}
