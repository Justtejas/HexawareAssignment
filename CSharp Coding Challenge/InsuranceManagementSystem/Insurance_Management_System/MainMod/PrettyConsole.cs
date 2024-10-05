namespace Insurance_Management_System.MainMod
{
    internal class PrettyConsole
    {
        public PrettyConsole() { }
        public void Print(string message, bool success)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}

