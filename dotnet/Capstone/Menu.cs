using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Menu
    {
        public static void Greeting()
        {
            Console.WriteLine($"Thank you for choosing the Vendo-Matic 800. Please select from one of the following options:");
        }

        public static void MainMenu()
        {
            Console.WriteLine($"(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.WriteLine($"(3) Exit");
        }

        public static void PurchaseMenu()
        {
                Console.WriteLine($"Please select one of the following options:");
                Console.WriteLine($"(1) Feed Money");
                Console.WriteLine($"(2) Select Product");
                Console.WriteLine($"(3) Finish Transaction");         
        }

            public static void FeedMoneyMenu()
            {
                Console.WriteLine($"(1) Put in $1.00");
                Console.WriteLine($"(2) Put in $2.00");
                Console.WriteLine($"(3) Put in $5.00");
                Console.WriteLine($"(4) Put in $10.00");
                Console.WriteLine($"(5) Put in $20.00");
                Console.WriteLine($"(6) Return to purchase menu");
            }
    }
}
