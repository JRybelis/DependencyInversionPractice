using Shop_2._0.Models;
using Shop_2._0.Models.Base;
using Shop_2._0.Services.Customer;

namespace Shop_2._0.Services.Shop.Sale
{
    public class SaleOperationService
    {
        private readonly SelectCustomerService _selectCustomerService;
        private Item _item;
        private int _quantity;
        

        public SaleOperationService(Models.Customer customer, Item item, int quantity)
        {
            _item = item;
            this._quantity = quantity;
        }
        public string SaleAttempt(Item stockItem, int quantity, Models.Customer customer)
        {
            customer = _selectCustomerService.SelectCustomer();

            string saleOperation = "";
            string insufficientStock = $"Insufficient stock levels of {stockItem}. Please offer the customer lower quantity or a substitute product.";
            string insufficientBalance = "Insufficient customer account balance. Please offer a lower quantity or a substitute product.";

            if (stockItem.Quantity < quantity)
            {
                saleOperation = insufficientStock;
            } else if (stockItem.Quantity * stockItem.PriceDecimal > customer.AccountBalance)
            {
                saleOperation = insufficientBalance;
            }
            else
            {
                stockItem.Quantity -= quantity;
                customer.AccountBalance -= quantity * stockItem.PriceDecimal;
            }
            return saleOperation;
        }
        
    }

    
}
