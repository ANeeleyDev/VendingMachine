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

        public override string PrintedMessage()
        {
            return "Glug Glug, Yum!";
        }

        //All chip items print "Crunch Crunch, Yum!"
        //All candy items print "Munch Munch, Yum!"
        //All drink items print "Glug Glug, Yum!"
        //All gum items print "Chew Chew, Yum!"

        //Drink drink1 = new Drink("Cola", 1.25M, 5);
        //Drink drink2 = new Drink("Dr. Salt", 1.50M, 5);
        //Drink drink3 = new Drink("Mountain Melter", 1.50M, 5);
        //Drink drink4 = new Drink("Heavy", 1.50M, 5);
    }
}
