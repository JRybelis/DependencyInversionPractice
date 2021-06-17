using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;
using Shop_2._0.Models;

namespace Shop_2._0.Services.Customer
{
    public class SelectCustomerAccountService
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IClearer _clearer;
        private List<Models.Customer> _customers;

        public SelectCustomerAccountService(IReader reader, IWriter writer, IClearer clearer)
        {
            _reader = reader;
            _writer = writer;
            _clearer = clearer;
        }

        

        Models.Customer SelectCustomer()
        {
            bool customerCheck = true;
            Models.Customer selectedCustomer = null;

            _clearer.Clear();
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

                foreach (var customer in _customers)
                {
                    if (firstNameToCheck == customer.Forename && lastNameToCheck == customer.Surname)
                    {
                        selectedCustomer = customer;
                        customerCheck = false;
                        return selectedCustomer;
                    }
                    else
                    {
                        Models.Customer newCustomer = new Models.Customer(0, firstNameToCheck, lastNameToCheck);
                        _customers.Add(newCustomer);
                        selectedCustomer = newCustomer;

                        customerCheck = false;
                        return selectedCustomer;
                    }
                }
                
            }
            return selectedCustomer;
        }
    }
}
