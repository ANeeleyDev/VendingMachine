using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

/*TO DO:
 * Fix bug that takes us to line 148 and tells us invalid entry when we try to close program
 * fix invalid entry so it works when user makes an invalid entry
 * do log
 * write unit tests
 * Add comments
 */


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
                VendingMachineItem firstPrice = inventoryInDictionary["A1"];
                decimal minimumPrice = firstPrice.ItemPrice;

                
                Console.WriteLine("");
                
                foreach (KeyValuePair<string, VendingMachineItem> item in inventoryInDictionary)
                {
                    if (item.Value.ItemPrice < minimumPrice)
                    {
                        minimumPrice = item.Value.ItemPrice;
                    }
                }

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
        }

        // This method subtracts items from the vending machine inventory, as the items are purchased by the user.
        public void subtractItemFromInventory()
        {


            // BQ Added 10-11-21
            decimal amountAfterSubtraction = 0;

            string selectMenuUserInput = Console.ReadLine();
            foreach (KeyValuePair<string, VendingMachineItem> item in inventoryInDictionary)
            {//(inventoryInDictionary.ContainsKey(selectMenuUserInput))

                if (selectMenuUserInput == (item.Key))
                {
                    // If the amount of items in the inventory is 0, then the user cannot purchase that item.  A message
                    // is displayed to the user, informing them that the item is sold out.  The purchase menu is displayed
                    // again, as well as a message that lets the user know how much they have fed into the machine to use
                    // for purchases.
                    if (item.Value.ItemAmountInInventory == 0)
                    {
                        Console.WriteLine(item.Key + " | " + item.Value.ItemName + " | SOLD OUT!");
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }

                    // If the user does not have enough money to buy the item, a message displays that informs the user they
                    // don't have enough money to use to purchase the selected item, and a message displays that lets the user
                    // know how much they have in the machine for purchases.
                    else if (amountFed < item.Value.ItemPrice)
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
                        item.Value.ItemAmountInInventory = item.Value.ItemAmountInInventory - 1;
                        //amountAfterSubtraction = amountFed - item.Value.ItemPrice;
                        amountFed = amountFed - item.Value.ItemPrice;

                        // The PrintedMessage() method is called for each item, based on that item's type.  The messages
                        // for each item type (candy, chip, drink, gum) are called from each type's class (an example of
                        // polymorphism).  The purchase menu is once-again displayed for the user to choose more items, and
                        // the amount the user has to use to make purchases is displayed.
                        Console.WriteLine(item.Value.PrintedMessage());
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                        writingToALog();
                    }


                }
                //else if (!selectMenuUserInput.Equals(item.Key))
                //{
                //    InvalidEntryMenu();
                //}
            }

















        }
        public void InvalidEntryMenu()
        {
            Console.WriteLine("Invalid entry");
            Menu.PurchaseMenu();
            Console.WriteLine("Current money provided: $" + amountFed);
            getPurchaseMenuInput();
        }

        // BQ Added 10-11-21
        public decimal exactAmountFed { get; private set; } = 0;

        public decimal amountFed { get; private set; } = 0;

        public void MoneyFed()
        {
            string feedMoneyUserInput = Console.ReadLine();
            int feedMoneyUserInputParsed = int.Parse(feedMoneyUserInput);

            if (feedMoneyUserInputParsed == 1)
            {
                amountFed += 1;

                // BQ Added 10-11-21
                exactAmountFed = 1;
            }
            else if (feedMoneyUserInputParsed == 2)
            {
                amountFed += 2;

                // BQ Added 10-11-21
                exactAmountFed = 2;
            }
            else if (feedMoneyUserInputParsed == 3)
            {
                amountFed += 5;

                // BQ Added 10-11-21
                exactAmountFed = 5;
            }
            else if (feedMoneyUserInputParsed == 4)
            {
                amountFed += 10;

                // BQ Added 10-11-21
                exactAmountFed = 10;
            }
            else if (feedMoneyUserInputParsed == 5)
            {
                amountFed += 20;

                // BQ Added 10-11-21
                exactAmountFed = 20;
            }
            else if (feedMoneyUserInputParsed == 6) //return to purchase menu at this point
            {
                amountFed += 0;
            }
            else
            {
                Console.WriteLine($"Invalid number entered, please select a number between 1 and 6");
            }

            // BQ Added 10-11-21
            // Directory and file name
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

        public void finishTransaction()
        {
            decimal quarterRemainder = amountFed % 0.25M;
            decimal numberOfQuarters = (amountFed - quarterRemainder) / 0.25M;
            decimal dimeRemainder = quarterRemainder % 0.10M;
            decimal numberOfDimes = (quarterRemainder - dimeRemainder) / 0.10M;
            decimal numberOfNickels = dimeRemainder / 0.05M;
            decimal totalChangeBack = ((numberOfQuarters * 0.25M) + (numberOfDimes * 0.10M) + (numberOfNickels * 0.05M));

            Console.WriteLine("Your total change back is $" + totalChangeBack + " (" + numberOfQuarters + " quarters, " + numberOfDimes + " dimes, " + numberOfNickels + " nickels.)");

        }


        public virtual void writingToALog()
        {
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";            
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.Now + " ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }

}


































//public void LoadInventory()
//{
//    string directory = Environment.CurrentDirectory;
//    string sourceFile = "vendingmachine.csv";
//    string fullPath = Path.Combine(directory, sourceFile);

//    // TODO break out the list into individual pieces
//    // TODO consolidate menus (get rid of purchase menus class and other menu classes and make them methods instead)
//    // TODO there are 5 items for each row
//    // TODO write code for when items are sold out
//    // TODO money returned code (25 cent, 10 cent, 5 cent)
//    // TODO log class

//}


//public void DispenseItem() //itemAmountInInventory - amountOfItemPurchased
//{

//}












//try
//{
//    using (StreamReader sr = new StreamReader(fullPath, true))
//    {
//        List<string> listOfVendingMachineItems = new List<string>();
//        while (!sr.EndOfStream)
//        {
//            string currentline = sr.ReadLine();
//            string[] arrayOfVendingMachineItems = currentline.Split('|');

//            for (int i = 0; i < arrayOfVendingMachineItems.Length; i++)
//            {
//                if (i <= 15)
//                {
//                    Chips chip = new Chips();
//                }
//            }


//            //foreach (string item in arrayOfVendingMachineItems)
//            //{
//            //    Console.WriteLine(item);
//            //}

//            //foreach (var item in arrayOfVendingMachineItems)
//            //{
//            //    if (arrayOfVendingMachineItems[3] == "Chip")
//            //    {
//            //        Chips arrayOfVendingMachineItems[0] = new Chips(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
//            //    }
//            //}


//            //Array["A1", "Potato Crisps", "3.05", "Chip", "A2", "Stackers", "1.45", "Chip"]


//            //listOfVendingMachineItems.AddRange(arrayOfVendingMachineItems);
//            //Console.WriteLine(listOfVendingMachineItems);
//        }
//    }
//}
//catch (Exception)
//{

//    Console.WriteLine($"You selected an incorrect number. Please choose a number between 1 and 3");
//}
