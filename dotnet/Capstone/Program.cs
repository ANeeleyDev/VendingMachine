using System;
using System.Collections.Generic;

namespace Capstone
{
  
    class Program
    {
        public void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Chips chip1 = new Chips("Potato Crisps", 3.05M, 5);
            Chips chip2 = new Chips("Stackers", 1.45M, 5);
            Chips chip3 = new Chips("Grain Waves", 2.75M, 5);
            Chips chip4 = new Chips("Cloud Popcorn", 3.65M, 5);

            Gum gum1 = new Gum("U-Chews", 0.85M, 5);
            Gum gum2 = new Gum("Little League Chew", 0.95M, 5);
            Gum gum3 = new Gum("Chiclets", 0.75M, 5);
            Gum gum4 = new Gum("Triplemint", 0.75M, 5);

            Candy candy1 = new Candy("Moonpie", 1.80M, 5);
            Candy candy2 = new Candy("Cowtales", 1.50M, 5);
            Candy candy3 = new Candy("Wonka Bar", 1.50M, 5);
            Candy candy4 = new Candy("Crunchie", 1.75M, 5);

            Beverage drink1 = new Beverage("Cola", 1.25M, 5);
            Beverage drink2 = new Beverage("Dr. Salt", 1.50M, 5);
            Beverage drink3 = new Beverage("Mountain Melter", 1.50M, 5);
            Beverage drink4 = new Beverage("Heavy", 1.50M, 5);

            Dictionary<string, VendingMachineItem> inventory = new Dictionary<string, VendingMachineItem>();
            inventory.Add("A1", chip1);
            inventory.Add("A2", chip2);
            inventory.Add("A3", chip3);
            inventory.Add("A4", chip4);
            inventory.Add("B1", candy1);
            inventory.Add("B2", candy2);
            inventory.Add("B3", candy3);
            inventory.Add("B4", candy4);
            inventory.Add("C1", drink1);
            inventory.Add("C2", drink2);
            inventory.Add("C3", drink3);
            inventory.Add("C4", drink4);
            inventory.Add("D1", gum1);
            inventory.Add("D2", gum2);
            inventory.Add("D3", gum3);
            inventory.Add("D4", gum4);

            Console.WriteLine(inventory);
            

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.LoadInventory();
        }
    }
}
