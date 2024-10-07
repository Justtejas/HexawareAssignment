using Task7_14.Model;

namespace Task7_14.DAO
{
    internal class BankServiceProviderImp:CustomerServiceProviderImp,IBankServiceProvider
    {
        private Account2[] accountList;
        private int accountCount;
        private const int MAX_ACCOUNTS = 100;
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }

        public BankServiceProviderImp(string branchName, string branchAddress)
        {
            BranchName = branchName;
            BranchAddress = branchAddress;
            accountList = new Account2[MAX_ACCOUNTS];
            accountCount = 0;
        }

        public Account2 CreateAccount(Customer customer, int accNo, string accType, decimal balance)
        {
            if (accountCount >= MAX_ACCOUNTS)
                throw new InvalidOperationException("Maximum number of accounts reached.");

            Account2 newAccount = null;

            switch (accType.ToLower())
            {
                case "savings":
                    newAccount = new SavingAccount2(accNo, "Savings", balance, customer, 4.5m);
                    break;
                case "current":
                    newAccount = new CurrentAccount2(accNo, "Current", balance, customer, 500m);
                    break;
                case "zerobalance":
                    newAccount = new ZeroBalanceAccount(accNo, "ZeroBalance", customer);
                    break;
                default:
                    throw new ArgumentException("Invalid account type.");
            }

            accountList[accountCount] = newAccount;
            accountCount++;
            AddAccount(newAccount);
            return newAccount;
        }

        public Account2[] ListAccounts()
        {
            Account2[] accountsToReturn = new Account2[accountCount];
            Array.Copy(accountList, accountsToReturn, accountCount);
            return accountsToReturn;
        }

        public void CalculateInterest()
        {
            foreach (var account in accountList)
            {
                if (account is SavingAccount2 savingsAccount)
                {
                    savingsAccount.CalculateInterest();
                }
            }
        }
    }
}
