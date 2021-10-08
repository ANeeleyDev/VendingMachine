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

        public override string PrintedMessage()
        {
            return "Crunch Crunch, Yum!";
        }

        //All chip items print "Crunch Crunch, Yum!"
        //All candy items print "Munch Munch, Yum!"
        //All drink items print "Glug Glug, Yum!"
        //All gum items print "Chew Chew, Yum!"


    }
}
