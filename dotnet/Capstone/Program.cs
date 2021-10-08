using System;

namespace Capstone
{
    class Program
    {
        public static void Main(string[] args)
        {

            Menu.MainMenu();
            string mainMenuUserInput = Console.ReadLine();
            int mainMenuUserInputParsedToInt = int.Parse(mainMenuUserInput);

            if (mainMenuUserInputParsedToInt == 1)
            {
                VendingMachine newFile = new VendingMachine();

                newFile.MakeDictionaryForInventory();
                newFile.DisplayMenuItems();
            }
            else if (mainMenuUserInputParsedToInt == 2)
            {
                Menu.PurchaseMenu();
                string purchaseMenuUserInput = Console.ReadLine();
                int purchaseMenuUserInputParsedToInt = int.Parse(purchaseMenuUserInput);

                if (purchaseMenuUserInputParsedToInt == 1)
                {
                    Menu.FeedMoneyMenu();
                    Transactionable newTransaction = new Transactionable();
                    newTransaction.MoneyFed();

                }
            }

        }
    }
}
