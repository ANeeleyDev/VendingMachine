using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        Dictionary<string, IVendingMachineItem> inventory = new Dictionary<string, IVendingMachineItem>(); //Dictionary<slot number, instance of a vending machine item>
        public void LoadInventory()
        {
            string directory = Environment.CurrentDirectory;
            string sourceFile = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, sourceFile);
            
            // TODO break out the list into individual pieces
            // TODO consolidate menus (get rid of purchase menus class and other menu classes and make them methods instead)
            // TODO there are 5 items for each row
            // TODO write code for when items are sold out
            // TODO money returned code (25 cent, 10 cent, 5 cent)
            // TODO log class
            try
            {
                using (StreamReader sr = new StreamReader(fullPath, true))
                {
                    List<string> listOfVendingMachineItems = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        string currentline = sr.ReadLine();
                        string[] listOfVendingMachineItemsInArray = currentline.Split('|');
                        listOfVendingMachineItems.AddRange(listOfVendingMachineItemsInArray);
                        Console.WriteLine(listOfVendingMachineItems);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine($"You selected an incorrect number. Please choose a number between 1 and 3");
            }
        }


        public void DispenseItem() //itemAmountInInventory - amountOfItemPurchased
        {

        }
    }

}
