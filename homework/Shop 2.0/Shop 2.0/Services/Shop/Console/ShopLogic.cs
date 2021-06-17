using System;
using System.Collections.Generic;
using System.Linq;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;

namespace Shop_2._0.BusinessLogic
{
    public class ShopLogic
    {
        private IWriter _writer;
        private IDescriber _describer;
        private List<Item> _shopInventory;
        private Customer _customer;

        public ShopLogic(IWriter writer, IDescriber describer, List<Item> shopInventory)
        {
            _writer = writer;
            _describer = describer;
            _shopInventory = shopInventory;
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

        public void Sale(string itemName, int quantity)
        {
            string saleOperation = ShopLogic.Sell(itemName, quantity, _customer);

            if (saleOperation == "")
            {
                Console.WriteLine($"You have sold {quantity} of {itemName} to {_customer}.");
            }
            else
            {
                Console.WriteLine(saleOperation);
            }
        }

        public void AddItems(string itemName, int quantity)
        {
            ShopLogic.AddItem(itemName, quantity);
            Console.WriteLine($"You have added {quantity} {itemName}s to the shop inventory.");
        }

        
        public string Sell(object itemSold, int quantity, Customer customer)
        {
            string saleOperation = "";
            switch (itemSold)
            {
                case "book":
                    var book = _shopInventory.FirstOrDefault(i => i is Book);
                    if (book.Quantity < quantity)
                    {
                        saleOperation = $"Insufficient stock levels of {book}. Please offer the customer lower quantity or a substitute product.";
                        break;
                    } else if (book.Quantity * book.PriceDecimal > customer.AccountBalance)
                    {
                        saleOperation =
                            "Insufficient customer account balance. Please offer a lower quantity or a substitute product.";
                        break;
                    }
                    else
                    {
                        book.Quantity -= quantity;
                        customer.AccountBalance -= quantity * book.PriceDecimal;
                        break;
                    } 
                case "cup":
                    var cup = _shopInventory.FirstOrDefault(i => i is Cup);
                    if (cup.Quantity < quantity)
                    {
                        saleOperation =
                            $"Insufficient stock levels of {cup}. Please offer the customer lower quantity or a substitute product.";
                        break;
                    }
                    else if (cup.Quantity * cup.PriceDecimal > customer.AccountBalance)
                    {
                        saleOperation =
                            "Insufficient customer account balance. Please offer a lower quantity or a substitute product.";
                        break;
                    }
                    else
                    {
                        cup.Quantity -= quantity;
                        customer.AccountBalance -= quantity * cup.PriceDecimal;
                        break;
                    }
                case "sweet":
                    var sweet = _shopInventory.FirstOrDefault(i => i is Sweet);
                    if (sweet.Quantity < quantity)
                    {
                        saleOperation = $"Insufficient stock levels of {sweet}. Please offer the customer lower quantity or a substitute product.";
                        break;
                    } else if (sweet.Quantity * sweet.PriceDecimal > customer.AccountBalance)
                    {
                        saleOperation =
                            "Insufficient customer account balance. Please offer a lower quantity or a substitute product.";
                        break;
                    }
                    else
                    {
                        sweet.Quantity -= quantity;
                        customer.AccountBalance -= quantity * sweet.PriceDecimal;
                        break;
                    }
            }

            return saleOperation;

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