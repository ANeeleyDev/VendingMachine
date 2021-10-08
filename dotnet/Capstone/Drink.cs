using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Drink : VendingMachineItem
    {
       
        public Drink(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

        //Drink drink1 = new Drink("Cola", 1.25M, 5);
        //Drink drink2 = new Drink("Dr. Salt", 1.50M, 5);
        //Drink drink3 = new Drink("Mountain Melter", 1.50M, 5);
        //Drink drink4 = new Drink("Heavy", 1.50M, 5);
    }
}
