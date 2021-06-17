using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;

namespace Shop_2._0.Services
{
    public class CustomerAccountService : Customer
    {
        private IWriter _writer;
        public void DisplayAccountBalance()
        {
            _writer.Write($"The customer's current account balance is at £{AccountBalance}.");
        }

        public void AccountTopUp(decimal topUpAmount)
        {
            AccountBalance += topUpAmount;
            _writer.Write($"The deposit of {topUpAmount} has been accepted.");
            DisplayAccountBalance();
        }
    }
}
