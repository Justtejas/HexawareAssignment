using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_14.Model
{
    internal class CurrentAccount2:Account2
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount2(int accountNumber, string accountType, decimal initialBalance, Customer customer, decimal overdraftLimit)
            : base(accountNumber, accountType, initialBalance, customer)
        {
            OverdraftLimit = overdraftLimit;
        }

        public decimal Withdraw(decimal amount)
        {
            if (AccountBalance - amount < -OverdraftLimit)
            {
                throw new InvalidOperationException($"Withdrawal exceeds overdraft limit of {OverdraftLimit:C}.");
            }

            AccountBalance -= amount;
            return AccountBalance;
        }
    }
}
