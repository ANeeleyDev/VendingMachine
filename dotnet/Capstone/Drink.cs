using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    // This class inherits from the VendingMachineItem class.
    public class Drink : VendingMachineItem
    {
        public Drink(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;
        }

        // This method overrides the PrintedMessage() function, and allows for each item type (e.g., chip, candy, etc.)
        // to have its own message display when that item type is purchased from the user.
        public override string PrintedMessage()
        {
            return "Glug Glug, Yum! Enjoy your beverage!";
        }
    }
}
