using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachineItem : IPrintedMessage
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
        public virtual string PrintedMessage()
        {
            return "";
        }

    }
}

















//for (int i = 0; i < arrayOfVendingMachineItems.Length; i++)
//{
//    if (i <= 15)
//    {
//        Chips chip = new Chips();
//    }
//}


//foreach (string item in arrayOfVendingMachineItems)
//{
//    Console.WriteLine(item);
//}

//foreach (var item in arrayOfVendingMachineItems)
//{
//    if (arrayOfVendingMachineItems[3] == "Chip")
//    {
//        Chips arrayOfVendingMachineItems[0] = new Chips(arrayOfVendingMachineItems[1], decimal.Parse(arrayOfVendingMachineItems[2]), 5);
//    }
//}


//Array["A1", "Potato Crisps", "3.05", "Chip", "A2", "Stackers", "1.45", "Chip"]


//listOfVendingMachineItems.AddRange(arrayOfVendingMachineItems);
//Console.WriteLine(listOfVendingMachineItems);