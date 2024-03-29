﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;

namespace Shop_2._0.Services.CustomerServices
{
    public class SelectCustomerService
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private List<Customer> _testData;

        public SelectCustomerService(IReader reader, IWriter writer, List<Customer> testData)
        {
            _reader = reader;
            _writer = writer;
            _testData = testData;
        }

          public Customer SelectCustomer()
        {
            bool customerCheck = true;
            Customer selectedCustomer = null;

            _writer.Clear();
            _writer.Write("Please enter the customer's first and last name: ");

            while (customerCheck)
            {
                string[] nameToCheck = new string[2];
                
                try
                {
                    nameToCheck = _reader.Read().ToUpper().Split("");
                }
                catch (Exception e)
                {
                    if (nameToCheck == null)
                    {
                        _writer.Write("Please supply a forename, followed by a surname.");
                        throw new ArgumentNullException(e.Message);
                    }
                }
            
                string firstNameToCheck = nameToCheck[0];
                string lastNameToCheck = nameToCheck[1];

                foreach (var customer in _testData)
                {
                    if (firstNameToCheck == customer.Forename && lastNameToCheck == customer.Surname)
                    {
                        selectedCustomer = customer;
                        customerCheck = false;
                        return selectedCustomer;
                    }
                    else
                    {
                        Customer newCustomer = new Customer(0, firstNameToCheck, lastNameToCheck);

                        selectedCustomer = newCustomer;
                        _testData.Add(newCustomer);
                        customerCheck = false;
                        return selectedCustomer;
                    }
                }
            }
            return selectedCustomer;
        }
    }
}
