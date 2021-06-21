using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Models;
using Shop_2._0.Models.Base;

namespace Shop_2._0.Data
{
    public class TestData
    {
        public static List<Item> GetTestItems() => new List<Item>()
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

        public static List<Customer> GetCustomers() => new List<Customer>()
        {
            new Customer(accountBalance:0.00M, "Jane", "Doe")
            {
                AccountBalance = 0.00M,
                Forename = "Johannes",
                Surname = "Hammerhands"
            }
        };
    }
}
