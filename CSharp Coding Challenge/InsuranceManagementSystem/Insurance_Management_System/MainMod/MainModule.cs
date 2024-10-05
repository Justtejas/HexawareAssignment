using Insurance_Management_System.MainMod.SubMenus;

namespace Insurance_Management_System.MainMod
{
    internal class MainModule
    {
        static void Main(string[] args)
        {
            //PolicyMenu menu = new PolicyMenu();
            //menu.Menu();
            UserMenu menu = new UserMenu();
            menu.Menu();
        }
    }
}
