using System;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VendingMachine newApplication = new VendingMachine();
            Menu.Greeting();
            Menu.MainMenu();
            newApplication.getMainMenuInput();
        }
    }
}

