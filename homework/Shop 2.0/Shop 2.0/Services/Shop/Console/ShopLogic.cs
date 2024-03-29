﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Shop_2._0.Data;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;
using Shop_2._0.Services.CustomerServices;
using Shop_2._0.Services.Shop.Sale;

namespace Shop_2._0.BusinessLogic
{
    public class ShopLogic
    {
        private readonly IWriter _writer;
        //private IDescriber _describer;
        private List<Item> _testData;
        private readonly SaleOperationOutputService _saleOperationOutputService;
        

        public ShopLogic(IWriter writer/*, IDescriber describer*/, List<Item> testData, SaleOperationOutputService saleOperationOutputService)
        {
            _writer = writer;
            //_describer = describer;
            _testData = testData;
            _saleOperationOutputService = saleOperationOutputService;
        }
        public void ListInventory()
        {
            var shopItems = _testData;
            _writer.Write("                  Shop inventory:                   ");
            _writer.Write("====================================================");
            _writer.Write("");
            
            foreach (var item in _testData)
            {
                _writer.Write($"{item.Name}, £{item.PriceDecimal}, in stock: {item.Quantity}.");
            }
            _writer.Write("");
            _writer.Write("====================================================");
        }

        public void Sell(object itemSold, int quantity, SelectCustomerService selectedCustomer)
        {
            var shopItems = _testData;
            switch (itemSold)
            { 
                case "book":
                    var book = shopItems.FirstOrDefault(i => i is Book); 
                    _saleOperationOutputService.SaleOutput(book, quantity, selectedCustomer);
                    break;
                case "cup":
                    var cup = shopItems.FirstOrDefault(i => i is Cup);
                    _saleOperationOutputService.SaleOutput(cup, quantity, selectedCustomer);
                    break;
                case "sweet":
                    var sweet = shopItems.FirstOrDefault(i => i is Sweet);
                    _saleOperationOutputService.SaleOutput(sweet, quantity, selectedCustomer);
                    break;
            }
        }

       public void AddItem(string itemName, int quantity)
        {
            var shopItems = _testData;
            switch (itemName)
            {
                case "book":
                    var book = shopItems.FirstOrDefault(i => i is Book);
                    book.Quantity += quantity;
                    break;
                case "cup":
                    var cup = shopItems.FirstOrDefault(i => i is Cup);
                    cup.Quantity += quantity;
                    break;
                case "sweet":
                    var sweet = shopItems.First(i => i is Sweet);
                    sweet.Quantity += quantity;
                    break;
            }
        }
        
    }
}