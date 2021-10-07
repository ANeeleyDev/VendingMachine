using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : IVendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
        public Candy(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }
    }
}
