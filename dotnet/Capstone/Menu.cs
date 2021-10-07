using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine($"Thank you for choosing the Vendo-Matic 800. Please select from one of the following options:");
            Console.WriteLine($"(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.WriteLine($"(3) Exit");
            string mainMenuUserInput = Console.ReadLine();
            int mainMenuUserInputParsedToInt = int.Parse(mainMenuUserInput);

            if (mainMenuUserInputParsedToInt == 1)
            {
                MenuItemsDisplayed();
            }

            void MenuItemsDisplayed() 
            {

                string directory = Environment.CurrentDirectory;
                string sourceFile = "vendingmachine.csv";
                string fullPath = Path.Combine(directory, sourceFile);

                try
                {
                    using (StreamReader sr = new StreamReader(fullPath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string currentline = sr.ReadLine();
                            Console.WriteLine(currentline);
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine($"You selected an incorrect number. Please choose a number between 1 and 3");
                }
            }
        }
        

       

        //Purchase Menu (1. Feed Money, 2. Select Product, 3. Finish Transaction)
        //Dollar Amount List Menu (user can select $1, $2, $5, $10 to add to their moneyFed)

    }
}
