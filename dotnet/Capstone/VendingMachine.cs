using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    // This class is the driver of the program.  It contains all the important methods/functions
    // that are the brains of the vending machine program.
    public class VendingMachine
    {
        // Create a dictionary that will store all data from the CSV file being pulled from.
        Dictionary<string, VendingMachineItem> inventoryInDictionary = new Dictionary<string, VendingMachineItem>();

        // This method gets the directory that the program and all related files are in and appends to it
        // the file name of the CSV file from which all data is pulled.  The resulting filepath will be
        // read from using a Streamreader.
        public Dictionary<string, VendingMachineItem> MakeDictionaryForInventory()
        {

            string directory = Environment.CurrentDirectory;
            string sourceFile = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, sourceFile);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath, true))
                {

                    while (!sr.EndOfStream)
                    {
                        // Read each line in the CSV file and store each line in an array of strings.  The Streamreader
                        // sees a pipe ('|') and breaks the data before it into a string, with each string having its own
                        // index in the array.
                        string currentline = sr.ReadLine();
                        string[] arrayOfVendingMachineItems = currentline.Split('|');

                        // The following if/else if statements will add to the dictionary initialized above.  If the
                        // Streamreader sees the word "Gum" in the CSV file, then a new gum object will be instantiated.
                        // That gum object (which is a vending machine item) will have the properties that were created
                        // in the VendingMachineItem class (i.e., name, price as a decimal, and quantity in inventory at
                        // the start of the application).  The item will be added to the dictionary with the vending
                        // machine item (with its properties) being the Value, and the slot number of each item being the Key.
                        // These if/else if statements will do this for all types of vending machine items (i.e., gum,
                        // candy, drink, chip).
                        if (arrayOfVendingMachineItems[3] == "Gum")
                        {
                            Gum gum = new Gum(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
                            inventoryInDictionary.Add(arrayOfVendingMachineItems[0], gum);
                        }
                        else if (arrayOfVendingMachineItems[3] == "Candy")
                        {
                            Candy candy = new Candy(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
                            inventoryInDictionary.Add(arrayOfVendingMachineItems[0], candy);
                        }
                        else if (arrayOfVendingMachineItems[3] == "Drink")
                        {
                            Drink drink = new Drink(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
                            inventoryInDictionary.Add(arrayOfVendingMachineItems[0], drink);
                        }
                        else if (arrayOfVendingMachineItems[3] == "Chip")
                        {
                            Chip chip = new Chip(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
                            inventoryInDictionary.Add(arrayOfVendingMachineItems[0], chip);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return inventoryInDictionary;
        }

        // This method gets the main menu input from the user (i.e., the first menu the user sees, which asks the user
        // to display the vending machine items, to choose to purchase an item, or to exit).
        public void getMainMenuInput()
        {
            try
            {
                string mainMenuUserInput = Console.ReadLine();
                int mainMenuUserInputParsedToInt = int.Parse(mainMenuUserInput);

                // If the user chooses 1 in the menu, the DisplayMenuItems() function is called, and the vending machine
                // items are displayed to the user.  The getMainMenuInput() function is called again, allowing for this
                // process to loop.
                if (mainMenuUserInputParsedToInt == 1)
                {
                    DisplayMenuItems();
                    Menu.MainMenu();
                    getMainMenuInput();
                }

                // If the user chooses 2 in the menu, the purchase menu displays, and the user is allowed to choose
                // options from that menu via the getPurchaseMenuInput() function.
                else if (mainMenuUserInputParsedToInt == 2)
                {
                    Menu.PurchaseMenu();
                    getPurchaseMenuInput();
                }
                else if (mainMenuUserInputParsedToInt == 3)
                {
                    Console.WriteLine("Thanks anyway.");
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                    Menu.MainMenu();
                    getMainMenuInput();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Menu.MainMenu();
                getMainMenuInput();
            }           
        }

        // This method allows for the user to purchase vending machine items.
        public void getPurchaseMenuInput()
        {
            string purchaseMenuUserInput = Console.ReadLine();
            int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

            // If the user chooses 1, the FeedMoneyMenu(), which displays the dollar amounts the user can feed into the
            // machine, is called.  The user has the opportunity at this point to enter a dollar amount via the 
            // MoneyFed() method.  When the user enters the dollar amount (from a list of valid dollar amounts), the current
            // total amount the user entered is displayed, and the purchase menu is called again (to allow for the user
            // to enter multiple dollar amounts).
            if (purchaseMenuUserInputParsedToInt == 1)
            {
                Menu.FeedMoneyMenu();
                MoneyFed();
                Menu.PurchaseMenu();
                Console.WriteLine("Current money provided: $" + amountFed);
                getPurchaseMenuInput();
            }

            // If the user enters 2, the method that displays the vending machine items is called again, and the user
            // is allowed to purchase vending machine items.  The user is prompted for a code to enter (slot number for
            // each item, e.g., A1, B4, etc.), and the program tells the user how much they have to spend on purchases.  When the
            // user purchases an item, the subtractItemFromInventory() method is called, and the item is subtracted from the
            // total inventory.
            else if (purchaseMenuUserInputParsedToInt == 2)
            {
                // Initialize a minimum price to be the first price in the CSV file, for the loop below.
                VendingMachineItem firstPrice = inventoryInDictionary["A1"];
                decimal minimumPrice = firstPrice.ItemPrice;
                Console.WriteLine("");
                
                // This foreach loop will check every item in the inventory dictionary, and if that item's price is lower
                // than the previous minimum price, then the new low price is set as the minimum price.
                foreach (KeyValuePair<string, VendingMachineItem> item in inventoryInDictionary)
                {
                    if (item.Value.ItemPrice < minimumPrice)
                    {
                        minimumPrice = item.Value.ItemPrice;
                    }
                }

                // If the amount the user feeds into the machine is less than the minimum price, then a message displays that the
                // user has insufficient funds.  Otherwise, the items to purchase are displayed, and the user has the option to
                // purchase an item.
                if (amountFed < minimumPrice)
                {
                       Console.WriteLine("Insufficient funds. Please add more money.");
                       Menu.PurchaseMenu();
                       Console.WriteLine("Current money provided: $" + amountFed);
                       getPurchaseMenuInput();
                } else
                {
                    DisplayMenuItems();
                    Console.WriteLine("Please enter a code for one of the following items. You have $" + amountFed + " to spend.");
                    subtractItemFromInventory();
                }
            }

            // If the user chooses 3, the finishTransaction() method is called, the program gives back to the user the
            // total money the user put into the machine (in quarters, dimes, and nickels), and updates the balance of the
            // vending machine to 0.  A parting message is displayed to the user, and the program ends.
            else if (purchaseMenuUserInputParsedToInt == 3)
            {
                finishTransaction();
                Console.WriteLine("Thank you for your business!");
            }
            else
            {
                Console.WriteLine("Invalid entry.");
                Menu.PurchaseMenu();
                getPurchaseMenuInput();
            }
        }

        // This method subtracts items from the vending machine inventory, as the items are purchased by the user.
        public void subtractItemFromInventory()
        {
            decimal originalAmountFed = 0;
            string selectMenuUserInput = Console.ReadLine();

                // The if statements below check if the input given by the user is inside the dictionary (i.e., if the vending
                // machine has that particular slot number).
                if (inventoryInDictionary.ContainsKey(selectMenuUserInput))
                {
                    // If the amount of items in the inventory is 0, then the user cannot purchase that item.  A message
                    // is displayed to the user, informing them that the item is sold out.  The purchase menu is displayed
                    // again, as well as a message that lets the user know how much they have fed into the machine to use
                    // for purchases.
                    if (inventoryInDictionary[selectMenuUserInput].ItemAmountInInventory == 0)
                    {
                        Console.WriteLine(inventoryInDictionary[selectMenuUserInput] + " | " + inventoryInDictionary[selectMenuUserInput].ItemName + " | SOLD OUT!");
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }

                    // If the user does not have enough money to buy the item, a message displays that informs the user they
                    // don't have enough money to use to purchase the selected item, and a message displays that lets the user
                    // know how much they have in the machine for purchases.
                    else if (amountFed < inventoryInDictionary[selectMenuUserInput].ItemPrice)
                    {
                        Console.WriteLine("Insufficient funds.  Please add more money.");
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }

                    // If the user has enough money in the machine, the item is purchased, and the inventory is
                    // updated by subtracting one from that item's amount in the inventory.
                    else
                    {
                        inventoryInDictionary[selectMenuUserInput].ItemAmountInInventory = inventoryInDictionary[selectMenuUserInput].ItemAmountInInventory - 1;
                        originalAmountFed = amountFed;
                        amountFed = amountFed - inventoryInDictionary[selectMenuUserInput].ItemPrice;

                        // When a purchase is made, a log is made to the external Log.txt file, and text is formatted per requirements.
                        string directory = Environment.CurrentDirectory;
                        string filename = "Log.txt";

                        string originalAmountFedInCurrency = String.Format("{0:C}", originalAmountFed);
                        string amountFedInCurrency = String.Format("{0:C}", amountFed);
                        string fullPath = Path.Combine(directory, filename);

                        try
                        {
                            using (StreamWriter sw = new StreamWriter(fullPath, true))
                            {
                                sw.Write(DateTime.Now + " ");
                                sw.Write(inventoryInDictionary[selectMenuUserInput].ItemName + " " + selectMenuUserInput + " ");
                                sw.Write(originalAmountFedInCurrency + " " + amountFedInCurrency + " ");
                                sw.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        // The PrintedMessage() method is called for each item, based on that item's type.  The messages
                        // for each item type (candy, chip, drink, gum) are called from each type's class (an example of
                        // polymorphism).  The purchase menu is once-again displayed for the user to choose more items, and
                        // the amount the user has to use to make purchases is displayed.
                        Console.WriteLine(inventoryInDictionary[selectMenuUserInput].PrintedMessage());
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }
                }
                else
                {
                InvalidEntryMenu();
                }
        }

        // This method displays a message that tells the user they entered an invalid entry in one of the menus.
        public void InvalidEntryMenu()
        {
            Console.WriteLine("Invalid entry");
            Menu.PurchaseMenu();
            Console.WriteLine("Current money provided: $" + amountFed);
            getPurchaseMenuInput();
        }


        public decimal exactAmountFed { get; private set; } = 0;
        public decimal amountFed { get; private set; } = 0;

        // This method allows for the user to enter money into the vending machine.  The feedmoney menu displays, showing the user
        // has options to enter money is $1, $2, $5, $10, and $20 amounts.  The user can choose an infinite amount of money
        // to feed into the machine.  Their amountFed gets updated every time they enter more money.
        public void MoneyFed()
        {
            string feedMoneyUserInput = Console.ReadLine();
            int feedMoneyUserInputParsed = int.Parse(feedMoneyUserInput);

            if (feedMoneyUserInputParsed == 1)
            {
                amountFed += 1;
                exactAmountFed = 1;
            }
            else if (feedMoneyUserInputParsed == 2)
            {
                amountFed += 2;
                exactAmountFed = 2;
            }
            else if (feedMoneyUserInputParsed == 3)
            {
                amountFed += 5;
                exactAmountFed = 5;
            }
            else if (feedMoneyUserInputParsed == 4)
            {
                amountFed += 10;
                exactAmountFed = 10;
            }
            else if (feedMoneyUserInputParsed == 5)
            {
                amountFed += 20;
                exactAmountFed = 20;
            }
            
            // If the user enters a 6, per the menu, they are returned to the purchase menu and no money is added to their balance
            // in the machine.
            else if (feedMoneyUserInputParsed == 6)
            {
                amountFed += 0;
            }
            else
            {
                Console.WriteLine($"Invalid number entered, please select a number between 1 and 6");
            }

            // This logs to the Log.txt file every time the user feeds money into the machine.
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";

            string exactAmountFedInCurrency = String.Format("{0:C}", exactAmountFed);
            string amountFedInCurrency = String.Format("{0:C}", amountFed);
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.Now + " ");
                    sw.Write("FEED MONEY: ");
                    sw.Write(exactAmountFedInCurrency + " " + amountFedInCurrency + " ");
                    sw.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // This method displays the menu items in the machine in a specific way (based off the CSV input file).  If the machine
        // has run out of a particular item, a sold out message is displayed.
        public void DisplayMenuItems()
        {
            foreach (KeyValuePair<string, VendingMachineItem> item in inventoryInDictionary)
            {
                if (item.Value.ItemAmountInInventory == 0)
                {
                    Console.WriteLine(item.Key + " | " + item.Value.ItemName + " | SOLD OUT!");
                }
                else
                {
                    Console.WriteLine(item.Key + " | " + item.Value.ItemName + " | $" + item.Value.ItemPrice + " | " + item.Value.ItemAmountInInventory + " in stock");
                }
            }
            Console.WriteLine("");
        }

        // This method will dispense change to the user, first in quarters, then in dimes, then in nickels, and it will then display
        // a message to the user.
        public void finishTransaction()
        {
            decimal quarterRemainder = amountFed % 0.25M;
            decimal numberOfQuarters = (amountFed - quarterRemainder) / 0.25M;
            decimal dimeRemainder = quarterRemainder % 0.10M;
            decimal numberOfDimes = (quarterRemainder - dimeRemainder) / 0.10M;
            decimal numberOfNickels = dimeRemainder / 0.05M;
            decimal totalChangeBack = ((numberOfQuarters * 0.25M) + (numberOfDimes * 0.10M) + (numberOfNickels * 0.05M));

            Console.WriteLine("Your total change back is $" + totalChangeBack + " (" + numberOfQuarters + " quarters, " + numberOfDimes + " dimes, " + numberOfNickels + " nickels.)");

            // Every time this method is called, the amount of change, and the vending machine balance at the end of the transaction
            // is printed to the Log.txt CSV input file.
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";

            string exactAmountFedInCurrency = String.Format("{0:C}", exactAmountFed);
            string amountFedInCurrency = String.Format("{0:C}", amountFed);
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.Now + " ");
                    sw.Write("GIVE CHANGE: ");
                    sw.Write(totalChangeBack + " $0.00");
                    sw.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}