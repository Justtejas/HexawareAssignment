using Task7_14.Model;

namespace Task7_14.Main
{
    internal class BankApp
    {
        //private static Bank2 bank = new();

        //public static void Main()
        //{
        //    int choice;

        //    do{
        //        Console.WriteLine("\nWelcome to the Banking System");
        //        Console.WriteLine("Please enter a command:");
        //        Console.WriteLine("1. create_account");
        //        Console.WriteLine("2. deposit");
        //        Console.WriteLine("3. withdraw");
        //        Console.WriteLine("4. get_balance");
        //        Console.WriteLine("5. transfer");
        //        Console.WriteLine("6. getAccountDetails");
        //        Console.WriteLine("7. exit");

        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1:
        //                CreateAccount();
        //                break;
        //            case 2:
        //                Deposit();
        //                break;
        //            case 3:
        //                Withdraw();
        //                break;
        //            case 4:
        //                GetBalance();
        //                break;
        //            case 5:
        //                Transfer();
        //                break;
        //            case 6:
        //                GetAccountDetails();
        //                break;
        //            case 7:
        //                Console.WriteLine("Exiting the system. Thank you!");
        //                break;
        //            default:
        //                Console.WriteLine("Invalid command, please try again.");
        //                break;
        //        }
        //    }while(choice !=7);
        //}

        //private static void CreateAccount()
        //{
        //    Console.WriteLine("\nEnter customer details:");
        //    Console.Write("First Name: ");
        //    string firstName = Console.ReadLine();
        //    Console.Write("Last Name: ");
        //    string lastName = Console.ReadLine();
        //    Console.Write("Email: ");
        //    string email = Console.ReadLine();
        //    Console.Write("Phone: ");
        //    string phone = Console.ReadLine();
        //    Console.Write("Address: ");
        //    string address = Console.ReadLine();

        //    Customer customer = new Customer(0, firstName, lastName, email, phone,address);

        //    Console.WriteLine("Choose Account Type:");
        //    Console.WriteLine("1. Savings");
        //    Console.WriteLine("2. Current");
        //    string accountType = Console.ReadLine().ToLower() == "1" ? "Savings" : "Current";

        //    Console.Write("Initial Deposit: ");
        //    decimal initialDeposit = decimal.Parse(Console.ReadLine());

        //    Account2 account = bank.CreateAccount(customer, accountType, initialDeposit);

        //    Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}");
        //}

        //private static void Deposit()
        //{
        //    Console.Write("\nEnter Account Number: ");
        //    int accountNumber = int.Parse(Console.ReadLine());

        //    Console.Write("Enter Deposit Amount: ");
        //    decimal amount = decimal.Parse(Console.ReadLine());
        //    try
        //    {
        //        decimal newBalance = bank.Deposit(accountNumber, amount);
        //        Console.WriteLine($"Deposit successful! New Balance: {newBalance:C}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void Withdraw()
        //{
        //    Console.Write("\nEnter Account Number: ");
        //    int accountNumber = int.Parse(Console.ReadLine());

        //    Console.Write("Enter Withdrawal Amount: ");
        //    decimal amount = decimal.Parse(Console.ReadLine());

        //    try
        //    {
        //        decimal newBalance = bank.Withdraw(accountNumber, amount);
        //        Console.WriteLine($"Withdrawal successful! New Balance: {newBalance:C}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void GetBalance()
        //{
        //    Console.Write("\nEnter Account Number: ");
        //    int accountNumber = int.Parse(Console.ReadLine());

        //    try
        //    {
        //        decimal balance = bank.GetAccountBalance(accountNumber);
        //        Console.WriteLine($"Current Balance: {balance:C}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void Transfer()
        //{
        //    Console.Write("\nEnter Source Account Number: ");
        //    int fromAccount = int.Parse(Console.ReadLine());

        //    Console.Write("Enter Destination Account Number: ");
        //    int toAccount = int.Parse(Console.ReadLine());

        //    Console.Write("Enter Transfer Amount: ");
        //    decimal amount = decimal.Parse(Console.ReadLine());

        //    try
        //    {
        //        bank.Transfer(fromAccount, toAccount, amount);
        //        Console.WriteLine("Transfer successful!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static void GetAccountDetails()
        //{
        //    Console.Write("\nEnter Account Number: ");
        //    int accountNumber = int.Parse(Console.ReadLine());

        //    try
        //    {
        //        bank.GetAccountDetails(accountNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
