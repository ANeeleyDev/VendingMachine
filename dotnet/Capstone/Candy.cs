using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : VendingMachineItem
    {
        
        public Candy(string itemName, decimal itemPrice, int itemAmountInInventory)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemAmountInInventory = itemAmountInInventory;

        }

        //Chip chip1 = new Chip("Potato Crisps", 3.05M, 5);
        //Chip chip2 = new Chip("Stackers", 1.45M, 5);
        //Chip chip3 = new Chip("Grain Waves", 2.75M, 5);
        //Chip chip4 = new Chip("Cloud Popcorn", 3.65M, 5);


    }
}
