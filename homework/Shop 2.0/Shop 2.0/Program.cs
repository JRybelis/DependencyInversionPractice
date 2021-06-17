using System;
using Shop_2._0.BusinessLogic;
using Shop_2._0.Interfaces;
using Shop_2._0.Loggers;
using Shop_2._0.Models;
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
            IDescriber bookDescriber = new Book();
            IDescriber cupDescriber = new Cup();
            IDescriber sweetDescriber = new Sweet();

            ShopUi shoppe = new ShopUi(writer, reader);
            shoppe.Open();

        }
    }
}
