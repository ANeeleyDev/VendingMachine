using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Beverage : VendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
        public Beverage(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

        Beverage drink1 = new Beverage("Cola", 1.25M, 5);
        Beverage drink2 = new Beverage("Dr. Salt", 1.50M, 5);
        Beverage drink3 = new Beverage("Mountain Melter", 1.50M, 5);
        Beverage drink4 = new Beverage("Heavy", 1.50M, 5);
    }
}
