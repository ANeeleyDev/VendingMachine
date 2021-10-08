using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips : IVendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
        public Chips(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

        Chips chip1 = new Chips("Potato Crisps", 3.05M, 5);
        Chips chip2 = new Chips("Stackers", 1.45M, 5);
        Chips chip3 = new Chips("Grain Waves", 2.75M, 5);
        Chips chip4 = new Chips("Cloud Popcorn", 3.65M, 5);


    }
}
