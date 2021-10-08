using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactionable
    {
        public static decimal amountFed { get; set; } = 0;
        public static void MoneyFed()
        {
            string feedMoneyUserInput = Console.ReadLine();
            int feedMoneyUserInputParsed = int.Parse(feedMoneyUserInput);

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
                else if (feedMoneyUserInputParsed == 6) //return to purchase menu at this point
                {
                    amountFed += 0;
                }
                else
                {
                    Console.WriteLine($"Invalid number entered, please select a number between 1 and 6");
                }
            }








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

