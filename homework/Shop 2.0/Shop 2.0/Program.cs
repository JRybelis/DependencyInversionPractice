using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Shop_2._0.BusinessLogic;
using Shop_2._0.Interfaces;
using Shop_2._0.Loggers;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;
using Shop_2._0.Services.CustomerServices;
using Shop_2._0.Services.Shop;
using Shop_2._0.Services.Shop.Console;

namespace Shop_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleLogger();
            IReader reader = new ConsoleLogger();
            IClearer clearer = new ConsoleLogger();
            ShopUi shopUi = new ShopUi(writer, reader);
            ShopLogic shopLogic = new ShopLogic(writer, new List<Item>());
            SelectCustomerService selectCustomerService =
                new SelectCustomerService(reader, writer, clearer, new List<Customer>());
            CustomerAccountService customerAccountService = new CustomerAccountService(accountBalance: 0.00M,
                forename: "John", surname: "Smith", clearer, writer, reader,
                new ReturnToMainMenuService(shopUi, reader));
            AddItemsService addItemsService = new AddItemsService(shopLogic, writer);
            IDescriber bookDescriber = new Book();
            IDescriber cupDescriber = new Cup();
            IDescriber sweetDescriber = new Sweet();

            Shop shoppe = new Shop(writer, clearer, isOpen: true, shopUi, shopLogic, selectCustomerService,
                customerAccountService, addItemsService);
            shoppe.Open();
        }
    }
}
