using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;

namespace Shop_2._0.Services.Shop.Sale
{
    public class SaleOperationOutputService
    {
        private readonly SaleOperationService _saleOperationService;
        private readonly IWriter _writer;

        public SaleOperationOutputService(SaleOperationService saleOperationService, IWriter writer)
        {
            _saleOperationService = saleOperationService;
            _writer = writer;
        }
        
        public void SaleOutput(Item itemName, int quantity, Models.Customer customer)
        {
            string saleOperation = _saleOperationService.SaleAttempt(itemName, quantity, customer);
                
            if (saleOperation == "")
            {
                _writer.Write($"You have sold {quantity} of {itemName} to {customer}.");
            }
            else
            {
                _writer.Write(saleOperation);
            }
        }
        
    }
}
