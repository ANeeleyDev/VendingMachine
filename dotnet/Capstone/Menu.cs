using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Menu
    {
        public static void Greeting()
        {
            Console.WriteLine($"Thank you for choosing the Vendo-Matic 800. Please select from one of the following options:");
        }

        public static void MainMenu()
        {
            Console.WriteLine($"(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.WriteLine($"(3) Exit");

            string mainMenuUserInput = Console.ReadLine();
            int mainMenuUserInputParsedToInt = int.Parse(mainMenuUserInput);

            if (mainMenuUserInputParsedToInt == 1)
            {
                VendingMachine newApplication = new VendingMachine();

                newApplication.MakeDictionaryForInventory();
                newApplication.DisplayMenuItems();

                MainMenu();
            }

            else if (mainMenuUserInputParsedToInt == 2)
            {
                PurchaseMenu();
            }

            static void PurchaseMenu()
            {
                Console.WriteLine($"Please select one of the following options:");
                Console.WriteLine($"(1) Feed Money");
                Console.WriteLine($"(2) Select Product");
                Console.WriteLine($"(3) Finish Transaction");
                Console.WriteLine($"");
                Console.WriteLine("Current money provided: $" + Transactionable.amountFed);

                string purchaseMenuUserInput = Console.ReadLine();
                int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

                if (purchaseMenuUserInputParsedToInt == 1)
                {
                    FeedMoneyMenu();
                }

                else if (purchaseMenuUserInputParsedToInt == 2)
                {
                    SelectProductMenu();
                }


            }

            static void FeedMoneyMenu()
            {
                Console.WriteLine($"(1) Put in $1.00");
                Console.WriteLine($"(2) Put in $2.00");
                Console.WriteLine($"(3) Put in $5.00");
                Console.WriteLine($"(4) Put in $10.00");
                Console.WriteLine($"(5) Put in $20.00");
                Console.WriteLine($"(6) Return to purchase menu");
                Transactionable.MoneyFed();
                PurchaseMenu();
            }

            static void SelectProductMenu()
            {
                VendingMachine newApplication2 = new VendingMachine();
                Console.WriteLine("Please select an item using its code: (you have $" + Transactionable.amountFed + " to spend)");
                newApplication2.DisplayMenuItems();

            }

            //    //if (mainMenuUserInputParsedToInt == 1)
            //    //{
            //    //    MainMenu.MenuItemsDisplayed();
            //    //}
            //else if (mainMenuUserInputParsedToInt == 2)
            //{
            //    Console.WriteLine($"(1) Feed Money");
            //    Console.WriteLine($"(2) Select Product");
            //    Console.WriteLine($"(3) Finish Transaction");
            //    string purchaseMenuUserInput = Console.ReadLine();
            //    int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

            //    if (purchaseMenuUserInputParsedToInt == 1)
            //    {
            //        Console.WriteLine($"Select dollar amount to feed into vending machine numbers 1 - 5, then select number 6 when ready to select items:");
            //        Console.WriteLine($"(1) $1.00");
            //        Console.WriteLine($"(2) $2.00");
            //        Console.WriteLine($"(3) $5.00");
            //        Console.WriteLine($"(4) $10.00");
            //        Console.WriteLine($"(5) $20.00");
            //        Console.WriteLine($"(6) select vending machine items");
            //        decimal vendingMachineMoneyBalance = 0;
            //        string userInputDollarAmountNumber = Console.ReadLine();




            //    }
            //}








            //Purchase Menu (1. Feed Money, 2. Select Product, 3. Finish Transaction)
            //Dollar Amount List Menu (user can select $1, $2, $5, $10 to add to their moneyFed)

        }
    }
}
