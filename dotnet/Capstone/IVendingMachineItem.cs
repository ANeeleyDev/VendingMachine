using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{ 
    public interface IVendingMachineItem
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmountInInventory { get; set; }
    }
}
