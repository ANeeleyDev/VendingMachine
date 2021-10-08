using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        Dictionary<string, IVendingMachineItem> inventory = new Dictionary<string, IVendingMachineItem>(); //Dictionary<slot number, instance of a vending machine item>
        Dictionary
        
        inventory["A1"] = Chips.chip1;
        
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

        }


        public void DispenseItem() //itemAmountInInventory - amountOfItemPurchased
        {

        }
    }

}











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
