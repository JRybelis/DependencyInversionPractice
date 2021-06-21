using System;
using System.Collections.Generic;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;
using Shop_2._0.Services.CustomerServices;
using Shop_2._0.Services.Shop;
using Shop_2._0.Services.Shop.Console;

namespace Shop_2._0.BusinessLogic
{
    internal class Shop
    {
        private readonly IWriter _writer;
        private bool _isOpen;
        private readonly ShopUi _shopUi;
        private readonly ShopLogic _shopLogic;
        private readonly AddItemsService _addItemsService;
        private readonly SelectCustomerService _selectCustomerService;
        private readonly CustomerAccountService _customerAccountService;

        public Shop(IWriter writer, bool isOpen, ShopUi shopUi, ShopLogic shopLogic, SelectCustomerService selectCustomerService, CustomerAccountService customerAccountService, AddItemsService addItemsService)
        {
            
            _writer = writer;
            _isOpen = isOpen;
            _shopUi = shopUi;
            _shopLogic = shopLogic;
            _selectCustomerService = selectCustomerService;
            _customerAccountService = customerAccountService;
            _addItemsService = addItemsService;
        }
       
        public void Open()
        {
            if (_isOpen)
            {
                throw new Exception("The shop manager app is already running.");
            }
            _isOpen = true;
            _writer.Write("Welcome to Lancaster Sweet Shoppe!");
            
            string[] menuSelections;
            do
            {
                menuSelections = _shopUi.MainMenu();
                switch (menuSelections[0])
                {
                    case "l":
                        _writer.Clear();
                        _shopLogic.ListInventory();
                        break;
                    case "s":
                        _writer.Clear();
                        _shopLogic.Sell(menuSelections[1], int.Parse(menuSelections[2]), _selectCustomerService);
                        break;
                    case "b":
                        _writer.Clear(); _customerAccountService.DisplayAccountBalance();
                        break;
                    case "t":
                        _writer.Clear();
                        _customerAccountService.AccountTopUp();
                        break;
                    case "a":
                        _writer.Clear();
                        _addItemsService.AddItems(menuSelections[1], int.Parse(menuSelections[2]));
                        break;
                }
            } while (menuSelections[0] != "c");
        }
    }
}