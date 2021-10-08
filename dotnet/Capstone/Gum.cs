using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : VendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
        public Gum(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

        Gum gum1 = new Gum("U-Chews", 0.85M, 5);
        Gum gum2 = new Gum("Little League Chew", 0.95M, 5);
        Gum gum3 = new Gum("Chiclets", 0.75M, 5);
        Gum gum4 = new Gum("Triplemint", 0.75M, 5);
    }
}
