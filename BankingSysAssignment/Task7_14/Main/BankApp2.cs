using Task7_14.DAO;
using Task7_14.Model;

namespace Task7_14.Main
{
    internal class BankApp2
    {
        public static void Main()
        {
            BankServiceProviderImp bankService = new BankServiceProviderImp("Main Branch", "123 Main St");

            string choice;
            do
            {
                Console.WriteLine("\n=== Banking System ===");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount(bankService);
                        break;
                    case "2":
                        Deposit(bankService);
                        break;
                    case "3":
                        Withdraw(bankService);
                        break;
                    case "4":
                        GetBalance(bankService);
                        break;
                    case "5":
                        Transfer(bankService);
                        break;
                    case "6":
                        GetAccountDetails(bankService);
                        break;
                    case "7":
                        ListAccounts(bankService);
                        break;
                    case "8":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "8");
        }

        private static void CreateAccount(BankServiceProviderImp bankService)
        {
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Customer customer = new Customer(customerId, firstName, lastName, email, phoneNumber, address);

            Console.WriteLine("Choose Account Type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Zero Balance Account");
            Console.Write("Enter your choice: ");
            string accountType = Console.ReadLine() switch
            {
                "1" => "savings",
                "2" => "current",
                "3" => "zerobalance",
                _ => throw new ArgumentException("Invalid account type.")
            };

            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            bankService.CreateAccount(customer, 1000 + bankService.ListAccounts().Length, accountType, initialBalance);
            Console.WriteLine($"Account created successfully for {customer.FirstName} {customer.LastName}.");
        }

        private static void Deposit(BankServiceProviderImp bankService)
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Amount to Deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                decimal newBalance = bankService.Deposit(accountNumber, amount);
                Console.WriteLine($"Successfully deposited {amount:C}. New Balance: {newBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void Withdraw(BankServiceProviderImp bankService)
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Amount to Withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                decimal newBalance = bankService.Withdraw(accountNumber, amount);
                Console.WriteLine($"Successfully withdrew {amount:C}. New Balance: {newBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void GetBalance(BankServiceProviderImp bankService)
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            try
            {
                decimal balance = bankService.GetAccountBalance(accountNumber);
                Console.WriteLine($"Account Balance: {balance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void Transfer(BankServiceProviderImp bankService)
        {
            Console.Write("Enter From Account Number: ");
            int fromAccountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter To Account Number: ");
            int toAccountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Amount to Transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            try
            {
                bool success = bankService.Transfer(fromAccountNumber, toAccountNumber, amount);
                if (success)
                {
                    Console.WriteLine($"Successfully transferred {amount:C} from account {fromAccountNumber} to {toAccountNumber}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void GetAccountDetails(BankServiceProviderImp bankService)
        {
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            try
            {
                string details = bankService.GetAccountDetails(accountNumber);
                Console.WriteLine(details);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ListAccounts(BankServiceProviderImp bankService)
        {
            Account2[] accounts = bankService.ListAccounts();
            Console.WriteLine("\n=== List of Accounts ===");
            foreach (var account in accounts)
            {
                Console.WriteLine(account.ToString());
            }
        }
    }
}
