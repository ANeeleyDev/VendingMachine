﻿using System;
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
    public class VendingMachine
    {
        Dictionary<string, VendingMachineItem> inventoryInDictionary = new Dictionary<string, VendingMachineItem>();
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
                        // "A1|Potato Crips|3.05|Chip"
                        string currentline = sr.ReadLine();
                        // ["A1", "Potato Crisps", "3.05", "Chip"]
                        string [] arrayOfVendingMachineItems = currentline.Split('|');

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

        public void getMainMenuInput()
        {
            string mainMenuUserInput = Console.ReadLine();
            int mainMenuUserInputParsedToInt = int.Parse(mainMenuUserInput);

            if (mainMenuUserInputParsedToInt == 1)
            {
                DisplayMenuItems();
                Menu.MainMenu();
                getMainMenuInput();
            }

            else if (mainMenuUserInputParsedToInt == 2)
            {
                Menu.PurchaseMenu();
                getPurchaseMenuInput();
            }
        }

 
        public void getPurchaseMenuInput()
        {
            string purchaseMenuUserInput = Console.ReadLine();
            int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

            if (purchaseMenuUserInputParsedToInt == 1)
            {
                Menu.FeedMoneyMenu();
                MoneyFed();
                Menu.PurchaseMenu();
                Console.WriteLine("Current money provided: $" + amountFed);              
                getPurchaseMenuInput();



            }

            else if (purchaseMenuUserInputParsedToInt == 2)
            {                                            
                DisplayMenuItems();
                Console.WriteLine("");
                Console.WriteLine("Please enter a code for one of the following items. You have $" + amountFed + " to spend.");
                //if (amountFed < 0.75M)
                //{
                //    Console.WriteLine("Insufficient funds");
                //    Menu.PurchaseMenu();
                //    Console.WriteLine("Current money provided: $" + amountFed);
                //    getPurchaseMenuInput();
                //}
                //else
                {
                    subtractItemFromInventory();
                }

            }
            else if (purchaseMenuUserInputParsedToInt == 3)
            {
                finishTransaction();
                Console.WriteLine("Thank you for your business!");
            }
        }

        public void subtractItemFromInventory() //based on code user entered
        {
            // BQ Added 10-11-21
            decimal amountAfterSubtraction = 0;

            string selectMenuUserInput = Console.ReadLine();
            foreach (KeyValuePair<string, VendingMachineItem> item in inventoryInDictionary)
            {//(inventoryInDictionary.ContainsKey(selectMenuUserInput))
                if (selectMenuUserInput == (item.Key))
                {
                    if (item.Value.ItemAmountInInventory == 0)
                    {
                        Console.WriteLine(item.Key + " | " + item.Value.ItemName + " | SOLD OUT!");
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }
                    else if (amountFed < item.Value.ItemPrice)
                    {
                        Console.WriteLine("Insufficient funds, feed more money");
                        Menu.PurchaseMenu();
                        Console.WriteLine("Current money provided: $" + amountFed);
                        getPurchaseMenuInput();
                    }
                    else
                    {
                        item.Value.ItemAmountInInventory = item.Value.ItemAmountInInventory - 1;

                        
                        amountAfterSubtraction = amountFed - item.Value.ItemPrice;

                        // Old line before Brad edited on 10-11-21
                        amountFed = amountFed - item.Value.ItemPrice;


                        Console.WriteLine(item.Value.PrintedMessage());
                        Menu.PurchaseMenu();

                        // Old line before Brad edited on 10-11-21
                        Console.WriteLine("Current money provided: $" + amountFed);

                        // BQ Added 10-11-21
                        //Console.WriteLine("Current money provided: $" + amountAfterSubtraction);

                        getPurchaseMenuInput();
                    }




                    // BQ Added 10-11-21
                    // Directory and file name
                    string directory = Environment.CurrentDirectory;
                    string filename = "Log.txt";


                    string newBalanceAfterPurchaseAsCurrency = String.Format("{0:C}", amountAfterSubtraction);
                    //string amountFedInCurrency = String.Format("{0:C}", amountFedBeforePurchase);
                    string fullPath = Path.Combine(directory, filename);

                    try
                    {
                        using (StreamWriter sw = new StreamWriter(fullPath, true))
                        {
                            sw.Write(DateTime.Now + " ");
                            sw.Write(item.Value.ItemName + " " + item.Key + " ");
                            sw.Write(amountFed + " " + newBalanceAfterPurchaseAsCurrency + " ");
                            sw.WriteLine();
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
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


        // BQ ADDED 10-11-21
        public void writingToALog()
        {
            //// Directory and file name
            //string directory = Environment.CurrentDirectory;
            //string filename = "Log.txt";

            //string fullPath = Path.Combine(directory, filename);

            //try
            //{
            //    using (StreamWriter sw = new StreamWriter(fullPath, true))
            //    {
            //        sw.Write(DateTime.Now + " ");
            //        sw.Write("$" + feedMoneyUserInputParsed + " " + "$" + amountFed + " ");
            //        sw.WriteLine();
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}

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
