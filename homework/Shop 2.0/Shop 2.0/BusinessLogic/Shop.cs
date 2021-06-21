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
        private readonly IClearer _clearer;
        private bool _isOpen;
        private readonly ShopUi _shopUi;
        private readonly ShopLogic _shopLogic;
        private readonly AddItemsService _addItemsService;
        private readonly SelectCustomerService _selectCustomerService;
        private readonly CustomerAccountService _customerAccountService;

        public Shop(IWriter writer, IClearer clearer, bool isOpen, ShopUi shopUi, ShopLogic shopLogic, SelectCustomerService selectCustomerService, CustomerAccountService customerAccountService, AddItemsService addItemsService)
        {
            
            _writer = writer;
            _clearer = clearer;
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
                        _clearer.Clear();
                        _shopLogic.ListInventory();
                        break;
                    case "s":
                        _clearer.Clear();
                        _shopLogic.Sell(menuSelections[1], int.Parse(menuSelections[2]), _selectCustomerService);
                        break;
                    case "b":
                        _clearer.Clear(); _customerAccountService.DisplayAccountBalance();
                        break;
                    case "t":
                        _clearer.Clear();
                        _customerAccountService.AccountTopUp();
                        break;
                    case "a":
                        _clearer.Clear();
                        _addItemsService.AddItems(menuSelections[1], int.Parse(menuSelections[2]));
                        break;
                }
            } while (menuSelections[0] != "c");
        }

        public static List<Item> ShopInventory = new List<Item>()
        {
            new Book()
            {
                Name = "The Unofficial Holy Bible for Minecrafters. A children's guide to the Old & New Testament",
                Quantity = 7,
                PriceDecimal = 25.49M
            },
            new Book()
            {
                Name = "The Action Bible. God's redemptive story.",
                Quantity = 1,
                PriceDecimal = 30.00M
            },
            new Sweet()
            {
                Name = "A little tin of sheep poo",
                Quantity = 20,
                PriceDecimal = 9.99M
            },
            new Sweet()
            {
                Name = "Fudge",
                Quantity = 40,
                PriceDecimal = 3.75M
            },
            new Sweet()
            {
                Name = "Brittle",
                Quantity = 80,
                PriceDecimal = 5.95M
            },
            new Cup()
            {
                Name = "Jacob's poison",
                Quantity = 13,
                PriceDecimal = 6.66M
            }
        };
    }
}