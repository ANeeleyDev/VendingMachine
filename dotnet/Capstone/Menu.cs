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
                MainMenu.MenuItemsDisplayed();
            }
            else if (mainMenuUserInputParsedToInt == 2)
            {
                Console.WriteLine($"(1) Feed Money");
                Console.WriteLine($"(2) Select Product");
                Console.WriteLine($"(3) Finish Transaction");
                string purchaseMenuUserInput = Console.ReadLine();
                int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

                if (purchaseMenuUserInputParsedToInt ==1)
                {
                    Console.WriteLine($"Select dollar amount to feed into vending machine numbers 1 - 5, then select number 6 when ready to select items:");
                    Console.WriteLine($"(1) $1.00");
                    Console.WriteLine($"(2) $2.00");
                    Console.WriteLine($"(3) $5.00");
                    Console.WriteLine($"(4) $10.00");
                    Console.WriteLine($"(5) $20.00");
                    Console.WriteLine($"(6) select vending machine items");
                    decimal vendingMachineMoneyBalance = 0;
                    string userInputDollarAmountNumber = Console.ReadLine();
                    int userInputDollarAmountNumberParsedToInt = int.Parse(userInputDollarAmountNumber);
                    if (userInputDollarAmountNumberParsedToInt == 1)
                    {                                    //TO DO:::::::: LOOK HERE YOU FOOLS!
                        vendingMachineMoneyBalance += 1; // create loop asking if user wants to keep inputting more money.
                    }                                    // show balace after each dollar amount inputted. 
                    else if (userInputDollarAmountNumberParsedToInt == 2)
                    {
                        vendingMachineMoneyBalance += 2;
                    }
                    else if (userInputDollarAmountNumberParsedToInt == 3)
                    {
                        vendingMachineMoneyBalance += 5;
                    }
                    else if (userInputDollarAmountNumberParsedToInt == 4)
                    {
                        vendingMachineMoneyBalance += 10;
                    }
                    else if (userInputDollarAmountNumberParsedToInt == 5)
                    {
                        vendingMachineMoneyBalance += 20;
                    }
                    else if (userInputDollarAmountNumberParsedToInt == 6)
                    {
                        //reutrn to main menu at this point
                    }
                    else
                    {
                        Console.WriteLine($"Invalid number entered, please select a number between 1 and 5");
                    }
                    
                         
                       
                }
            }


          
        }
        

       

        //Purchase Menu (1. Feed Money, 2. Select Product, 3. Finish Transaction)
        //Dollar Amount List Menu (user can select $1, $2, $5, $10 to add to their moneyFed)

    }
}
