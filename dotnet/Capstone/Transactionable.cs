using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactionable
    {
        public decimal VendingMachineBalance { get; private set; }
        public decimal MoneyFed()
        {
            decimal amountFed = 0;
            return amountFed;
        }
        public decimal AmountPaid()
        {
            decimal amountPaid = 0;
            return amountPaid;
        }
        public decimal AmountReturned(decimal amountFed, decimal amountPaid)
        {
            return amountFed - amountPaid;
        }

        public bool AcceptMoney() //if not enough money fed, money will not be accepted and will prompt an error
        {
            return true;
        }
    }
}
