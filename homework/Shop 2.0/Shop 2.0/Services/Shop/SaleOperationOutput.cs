using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.BusinessLogic;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;

namespace Shop_2._0.Services.Shop
{
    public class SaleOperationOutput
    {
        private readonly ShopLogic _shopLogic;
        private Customer _customer;
        private IWriter _writer;
        public void SaleOutput(string itemName, int quantity)
        {
            string saleOperation = _shopLogic.Sell(itemName, quantity, _customer);

            if (saleOperation == "")
            {
                _writer.Write($"You have sold {quantity} of {itemName} to {_customer}.");
            }
            else
            {
                _writer.Write(saleOperation);
            }
        }
        
    }
}
