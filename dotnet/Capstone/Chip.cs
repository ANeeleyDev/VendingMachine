using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chip : VendingMachineItem
    {
        public Chip(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

       


    }
}
