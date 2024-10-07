namespace Task7_14.Model
{
    internal class Bank2
    {
        private Dictionary<int, Account2> accounts = new();
        private int nextAccountNumber = 1001;

        public Account2 CreateAccount(Customer customer, string accType, decimal balance)
        {
            int accountNumber = nextAccountNumber++;
            Account2 newAccount = new(accountNumber, accType, balance, customer);
            accounts[accountNumber] = newAccount;
            return newAccount;
        }

        public decimal GetAccountBalance(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].AccountBalance;
            }
            else
            {
                throw new ArgumentException("Account number does not exist.");
            }
        }

        public decimal Deposit(int accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account2 account = accounts[accountNumber];
                account.AccountBalance += amount;
                return account.AccountBalance;
            }
            else
            {
                throw new ArgumentException("Account number does not exist.");
            }
        }

        public decimal Withdraw(int accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account2 account = accounts[accountNumber];
                if (account.AccountBalance >= amount)
                {
                    account.AccountBalance -= amount;
                    return account.AccountBalance;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance.");
                }
            }
            else
            {
                throw new ArgumentException("Account number does not exist.");
            }
        }

        public void Transfer(int fromAccountNumber, int toAccountNumber, decimal amount)
        {
            if (!accounts.ContainsKey(fromAccountNumber))
            {
                throw new ArgumentException("Source account number does not exist.");
            }

            if (!accounts.ContainsKey(toAccountNumber))
            {
                throw new ArgumentException("Destination account number does not exist.");
            }

            Withdraw(fromAccountNumber, amount);
            Deposit(toAccountNumber, amount);  
        }

        public void GetAccountDetails(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account2 account = accounts[accountNumber];
                account.ToString();
            }
            else
            {
                throw new ArgumentException("Account number does not exist.");
            }
        }
    }
}
