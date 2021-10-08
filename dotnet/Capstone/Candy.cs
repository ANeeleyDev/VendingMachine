using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : VendingMachineItem
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

        Candy candy1 = new Candy("Moonpie", 1.80M, 5);
        Candy candy2 = new Candy("Cowtales", 1.50M, 5);
        Candy candy3 = new Candy("Wonka Bar", 1.50M, 5);
        Candy candy4 = new Candy("Crunchie", 1.75M, 5);
    }
}
