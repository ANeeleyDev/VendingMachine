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
    }
}
