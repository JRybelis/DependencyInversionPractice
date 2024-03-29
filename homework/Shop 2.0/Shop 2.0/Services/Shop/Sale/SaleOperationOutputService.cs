﻿using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;
using Shop_2._0.Services.CustomerServices;
using Shop_2._0.Services.Shop.Console;

namespace Shop_2._0.Services.Shop.Sale
{
    public class SaleOperationOutputService
    {
        private readonly SaleOperationService _saleOperationService;
        private readonly IWriter _writer;
        private readonly ReturnToMainMenuService _returnToMainMenuService;

        public SaleOperationOutputService(SaleOperationService saleOperationService, IWriter writer, ReturnToMainMenuService returnToMainMenuService)
        {
            _saleOperationService = saleOperationService;
            _writer = writer;
            _returnToMainMenuService = returnToMainMenuService;
        }
        
        public void SaleOutput(Item itemName, int quantity, SelectCustomerService selectedCustomer)
        {
            string saleOperation = _saleOperationService.SaleAttempt(itemName, quantity, selectedCustomer);
                
            if (saleOperation == "")
            {
                _writer.Write($"You have sold {quantity} of {itemName} to {selectedCustomer}.");
                _returnToMainMenuService.ReturnToMainMenu();
            }
            else
            {
                _writer.Write(saleOperation);
                _returnToMainMenuService.ReturnToMainMenu();
            }
        }
        
    }
}
