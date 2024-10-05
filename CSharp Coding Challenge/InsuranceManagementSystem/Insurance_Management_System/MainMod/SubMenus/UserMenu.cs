using Insurance_Management_System.DAO;
using Insurance_Management_System.Model;

namespace Insurance_Management_System.MainMod.SubMenus
{
    internal class UserMenu
    {
        public UserMenu() { 
            Console.Title = "User Menu";
        }

        readonly IPolicyService _policyService = new InsuranceServiceImpl();
        readonly PrettyConsole _prettyConsole = new();
        public void Menu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.Write("> ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        RegisterMenu();
                        break;
                    case 2:
                        LoginMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (choice != 3);
        }
        public void RegisterMenu()
        {
            User user = new();
            Console.WriteLine("Enter User Name");
            Console.Write("> ");
            user.UserName = Console.ReadLine();
            Console.WriteLine("\nEnter Password");
            Console.Write("> ");
            user.Password = Console.ReadLine();
            Register(user);
        }

        public void Register(User user)
        {
            bool status = _policyService.RegisterUser(user);
            if (status)
            {
                _prettyConsole.Print("Registered Successfull", true);
            }
            else
            {
                _prettyConsole.Print("Could not register user", false);
            }
        }
        public void LoginMenu()
        {
            User user = new();
            Console.WriteLine("Enter User Name");
            Console.Write("> ");
            user.UserName = Console.ReadLine();
            Console.WriteLine("\nEnter Password");
            Console.Write("> ");
            user.Password = Console.ReadLine();
            LoginUser(user);
        }
        public bool LoginUser(User user)
        {
            bool status = _policyService.Login(user.UserName,user.Password);
            if (status)
            {
                _prettyConsole.Print("Registered Successfull", true);
            }
            else
            {
                _prettyConsole.Print("Could not register user", false);
            }
            return status;
        }
    }

}
