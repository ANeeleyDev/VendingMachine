using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactionable
    {
        public decimal VendingMachineBalance { get; private set; }
        public void MoneyFed()
        {
            decimal amountFed = 0;

            string feedMoneyUserInput = Console.ReadLine();
            int feedMoneyUserInputParsed = int.Parse(feedMoneyUserInput);

            string userInputYesOrNo = "";
                if (feedMoneyUserInputParsed == 1)
                {
                    amountFed += 1;
                }
                else if (feedMoneyUserInputParsed == 2)
                {
                    amountFed += 2;
                }
                else if (feedMoneyUserInputParsed == 3)
                {
                    amountFed += 5;
                }
                else if (feedMoneyUserInputParsed == 4)
                {
                    amountFed += 10;
                }
                else if (feedMoneyUserInputParsed == 5)
                {
                    amountFed += 20;
                }
                else if (feedMoneyUserInputParsed == 6) //return to main menu at this point
                {

                }
                else
                {
                    Console.WriteLine($"Invalid number entered, please select a number between 1 and 6");
                }
                Console.WriteLine("Current money provided: $" + amountFed);

                Console.WriteLine("Would like to enter more money? (Y/N)");
                userInputYesOrNo = Console.ReadLine();


                    if (feedMoneyUserInputParsed == 1)
                    {
                        amountFed += 1;
                    }
                    else if (feedMoneyUserInputParsed == 2)
                    {
                        amountFed += 2;
                    }
                    else if (feedMoneyUserInputParsed == 3)
                    {
                        amountFed += 5;
                    }
                    else if (feedMoneyUserInputParsed == 4)
                    {
                        amountFed += 10;
                    }
                    else if (feedMoneyUserInputParsed == 5)
                    {
                        amountFed += 20;
                    }
                    else if (feedMoneyUserInputParsed == 6) //return to main menu at this point
                    {

                    }
                    else
                    {
                        Console.WriteLine($"Invalid number entered, please select a number between 1 and 6");
                    }
                    Console.WriteLine("Current money provided: $" + amountFed);
                    

                
            

            //public decimal AmountPaid()
            //{
            //    decimal amountPaid = 0;
            //    return amountPaid;
            //}
            //public decimal AmountReturned(decimal amountFed, decimal amountPaid)
            //{
            //    return amountFed - amountPaid;
            //}

            //public bool AcceptMoney() //if not enough money fed, money will not be accepted and will prompt an error
            //{
            //    return true;
            //}
        }
    }
}
