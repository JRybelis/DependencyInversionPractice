using System;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Models
{
    public class Customer
    {
        public decimal AccountBalance { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public Customer(decimal accountBalance, string forename, string surname)
        {
            AccountBalance = accountBalance;
            Forename = forename;
            Surname = surname;
        }
    }
}