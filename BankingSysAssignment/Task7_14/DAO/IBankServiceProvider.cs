using Task7_14.Model;

namespace Task7_14.DAO
{
    internal interface IBankServiceProvider
    {
        Account2 CreateAccount(Customer customer, int accNo, string accType, decimal balance);
        Account2[] ListAccounts();
        void CalculateInterest();
    }
}
