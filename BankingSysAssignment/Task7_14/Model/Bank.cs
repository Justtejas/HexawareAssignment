namespace Task7_14.Model
{
    //internal class Bank
    //{
    //    public static void Main(string[] args)
    //    {
    //        //Account account = new Account(1, "Savings", 5000);
    //        //account.Deposit(450);
    //        //account.Withdraw(600);
    //        //account.CalculateInterest();
    //        int choice;
    //        do
    //        {
    //            Console.WriteLine("1. Savings Account");
    //            Console.WriteLine("2. Current Account");
    //            Console.WriteLine("3. Exit");
    //            Console.Write("> ");
    //            choice = Convert.ToInt32(Console.ReadLine());
    //            switch (choice)
    //            {
    //                case 1:
    //                    Console.WriteLine("Enter Account Number:");
    //                    int accNum = Convert.ToInt32(Console.ReadLine());
    //                    Console.WriteLine("Enter Balance:");
    //                    decimal balance = Convert.ToDecimal(Console.ReadLine());
    //                    Account account = new SavingAccount(accNum,balance);
    //                    SavingAccountMenu(account);
    //                    break;
    //                case 2:
    //                    Console.WriteLine("Enter Account Number:");
    //                    int accNumber = Convert.ToInt32(Console.ReadLine());
    //                    Console.WriteLine("Enter Balance:");
    //                    decimal currentAccBalance = Convert.ToDecimal(Console.ReadLine());
    //                    Account currentAccount = new CurrentAccount(accNumber,currentAccBalance);
    //                    CurrentAccMenu(currentAccount);
    //                    break;
    //                case 3:
    //                    Console.WriteLine("Exiting");
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid option");
    //                    break;
    //            }

    //        }while(choice != 3);
    //    }

    //    public static void SavingAccountMenu(Account savingAccount)
    //    {
    //        int choice;
    //        do
    //        {
    //            Console.WriteLine("1. Deposit");
    //            Console.WriteLine("2. Withdraw");
    //            Console.WriteLine("3. Calculate Interest");
    //            Console.WriteLine("4. Exit");
    //            Console.Write("> ");
    //            choice = Convert.ToInt32(Console.ReadLine());
    //            switch (choice)
    //            {
    //                case 1:
    //                    Console.WriteLine("Enter the amount to deposit");
    //                    int deposit = Convert.ToInt32(Console.ReadLine());
    //                    savingAccount.Deposit(deposit);
    //                    break;
    //                case 2:
    //                    Console.WriteLine("Enter amount to withdraw");
    //                    float amount = float.Parse(Console.ReadLine());
    //                    savingAccount.Withdraw(amount);
    //                    break;
    //                case 3:
    //                    savingAccount.CalculateInterest();
    //                    break;
    //                case 4:
    //                    Console.WriteLine("Exiting");
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid option");
    //                    break;
    //            }
    //        } while (choice != 4);
    //    }

    //    public static void CurrentAccMenu(Account currentAccount)
    //    {
    //        int choice;
    //        do
    //        {
    //            Console.WriteLine("1. Deposit");
    //            Console.WriteLine("2. Withdraw");
    //            Console.WriteLine("3. Exit");
    //            Console.Write("> ");
    //            choice = Convert.ToInt32(Console.ReadLine());
    //            switch (choice)
    //            {
    //                case 1:
    //                    Console.WriteLine("Enter the amount to deposit");
    //                    int deposit = Convert.ToInt32(Console.ReadLine());
    //                    currentAccount.Deposit(deposit);
    //                    break;
    //                case 2:
    //                    Console.WriteLine("Enter amount to withdraw");
    //                    float amount = float.Parse(Console.ReadLine());
    //                    currentAccount.Withdraw(amount);
    //                    break;
    //                case 3:
    //                    Console.WriteLine("Exiting");
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid option");
    //                    break;
    //            }
    //        } while (choice != 4);
    //    }
    //}
}


