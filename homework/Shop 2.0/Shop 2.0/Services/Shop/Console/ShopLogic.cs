﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;

using Shop_2._0.Services.Shop.Sale;

namespace Shop_2._0.BusinessLogic
{
    public class ShopLogic
    {
        private readonly IWriter _writer;
        private Customer _customer;
        private IDescriber _describer;
        private List<Item> _shopInventory;
        private readonly SaleOperationService _saleOperationService;
        private readonly SaleOperationOutputService _saleOperationOutputService;
        

        public ShopLogic(IWriter writer, IDescriber describer, List<Item> shopInventory, Customer customer)
        {
            _writer = writer;
            _describer = describer;
            _shopInventory = shopInventory;
            _customer = customer;
        }
        public void ListInventory()
        {
               
            _writer.Write("                  Shop inventory:                   ");
            _writer.Write("====================================================");
            _writer.Write("");
            
            foreach (var item in _shopInventory)
            {
                _writer.Write($"{item.Name}, £{item.PriceDecimal}, in stock: {item.Quantity}.");
            }
            _writer.Write("");
            _writer.Write("====================================================");
        }

        public void Sell(object itemSold, int quantity, Customer customer)
        {

            switch (itemSold)
            {
                case "book":
                    var book = _shopInventory.FirstOrDefault(i => i is Book); 
                    //_saleOperationService.SaleAttempt(book, quantity, customer);
                    _saleOperationOutputService.SaleOutput(book, quantity, customer);
                    break;
                case "cup":
                    var cup = _shopInventory.FirstOrDefault(i => i is Cup);
                    //_saleOperationService.SaleAttempt(cup, quantity, customer);
                    _saleOperationOutputService.SaleOutput(cup, quantity, customer);
                    break;
                case "sweet":
                    var sweet = _shopInventory.FirstOrDefault(i => i is Sweet);
                    //_saleOperationService.SaleAttempt(sweet, quantity, customer);
                    _saleOperationOutputService.SaleOutput(sweet, quantity, customer);
                    break;
            }
        }

       

        public void AddItems(string itemName, int quantity)
        {
            ShopLogic.AddItem(itemName, quantity);
            Console.WriteLine($"You have added {quantity} {itemName}s to the shop inventory.");
        }
        public void AddItem(string itemName, int quantity)
        {
            switch (itemName)
            {
                case "book":
                    var book = _shopInventory.FirstOrDefault(i => i is Book);
                    book.Quantity += quantity;
                    break;
                case "cup":
                    var cup = _shopInventory.FirstOrDefault(i => i is Cup);
                    cup.Quantity += quantity;
                    break;
                case "sweet":
                    var sweet = _shopInventory.First(i => i is Sweet);
                    sweet.Quantity += quantity;
                    break;
            }
        }
        
    }
}