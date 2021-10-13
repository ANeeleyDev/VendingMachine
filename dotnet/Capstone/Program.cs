using System;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a new vending machine object.
            VendingMachine newApplication = new VendingMachine();
            
            // Load the inventory into the machine from the CSV input file.
            newApplication.MakeDictionaryForInventory();
            
            // Call the greeting and main menu upon starting the program, and allow for the user to enter input from the main menu.
            Menu.Greeting();
            Menu.MainMenu();
            newApplication.getMainMenuInput();
        }
    }
}

