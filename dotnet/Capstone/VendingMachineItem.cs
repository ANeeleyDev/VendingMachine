using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{ 
    public class VendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }

        Dictionary<string, VendingMachineItem> inventory = new Dictionary<string, VendingMachineItem>(); //Dictionary<slot number, instance of a vending machine item>
        
 
        

    }


   

}
