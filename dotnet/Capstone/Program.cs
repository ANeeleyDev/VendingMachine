using System;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log log = new Log();
            log.WritingAFile();
            VendingMachine newApplication = new VendingMachine();
            newApplication.MakeDictionaryForInventory();
            Menu.Greeting();
            Menu.MainMenu();
            newApplication.getMainMenuInput();
        }
    }
}

