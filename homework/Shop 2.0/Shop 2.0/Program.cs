using System;
using System.Collections.Generic;
using Shop_2._0.BusinessLogic;
using Shop_2._0.Data;
using Shop_2._0.Interfaces;
using Shop_2._0.Loggers;
using Shop_2._0.Models;
using Shop_2._0.Services.CustomerServices;
using Shop_2._0.Services.Shop;
using Shop_2._0.Services.Shop.Console;
using Shop_2._0.Services.Shop.Sale;

namespace Shop_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleLogger();
            IReader reader = new ConsoleLogger();
            ShopUi shopUi = new ShopUi(writer, reader);
            ReturnToMainMenuService returnToMainMenu = new ReturnToMainMenuService(shopUi, reader);
            SaleOperationService saleOperation =
                new SaleOperationService(new SelectCustomerService(reader, writer, TestData.GetCustomers()), new Book(),
                    Int32.MaxValue);

            SaleOperationOutputService saleOperationOutput = new SaleOperationOutputService(saleOperation, writer, returnToMainMenu);
            ShopLogic shopLogic = new ShopLogic(writer, TestData.GetTestItems(), saleOperationOutput);
            SelectCustomerService selectCustomerService =
                new SelectCustomerService(reader, writer, new List<Customer>());
            CustomerAccountService customerAccountService = new CustomerAccountService(accountBalance: 0.00M,
                forename: "John", surname: "Smith", writer, reader,
                new ReturnToMainMenuService(shopUi, reader));
            AddItemsService addItemsService = new AddItemsService(shopLogic, writer);
            IDescriber bookDescriber = new Book();
            IDescriber cupDescriber = new Cup();
            IDescriber sweetDescriber = new Sweet();

            Shop shoppe = new Shop(writer, isOpen: true, shopUi, shopLogic, selectCustomerService,
                customerAccountService, addItemsService);
            shoppe.Open();
        }
    }
}
