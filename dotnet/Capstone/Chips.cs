using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips : VendingMachineItem
    {
        public Chips(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

       


    }
}
