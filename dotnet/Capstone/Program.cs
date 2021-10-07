using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.LoadInventory();
        }
    }
}
