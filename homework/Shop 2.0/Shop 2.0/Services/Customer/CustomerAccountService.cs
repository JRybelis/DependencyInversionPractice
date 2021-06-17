using System;
using Shop_2._0.Interfaces;
using Shop_2._0.Services.Shop.Console;
using static System.Decimal;

namespace Shop_2._0.Services.Customer
{
    public class CustomerAccountService : Models.Customer
    {
        private readonly IClearer _clearer;
        private readonly IWriter _writer;
        private readonly IReader _reader;
        private readonly ReturnToMainMenuService _returnToMainMenuService;

        public CustomerAccountService(decimal accountBalance, string forename, string surname, IClearer clearer, IWriter writer, IReader reader, ReturnToMainMenuService returnToMainMenuService) : base(accountBalance, forename, surname)
        {
            _clearer = clearer;
            _writer = writer;
            _reader = reader;
            _returnToMainMenuService = returnToMainMenuService;
        }
        public void DisplayAccountBalance()
        {
            _clearer.Clear();
            _writer.Write($"The customer's current account balance is at £{AccountBalance}. Would you like to top up? Y/N");
            try
            {
                char choice = Convert.ToChar(_reader.Read().ToLower());
                if (choice == 'Y')
                {
                    AccountTopUp();
                }
                else
                {
                    _writer.Write("Returning to main menu:");
                    _returnToMainMenuService.ReturnToMainMenu();
                }
            }
            catch (Exception e)
            {
                _writer.Write(e.Message);
                throw;
            }
        }

        public void AccountTopUp()
        {
            _writer.Write("Please enter the amount to top up by: $$.¢¢");
            decimal topUpAmount = Parse(_reader.Read());

            AccountBalance += topUpAmount;
            _writer.Write($"The deposit of {topUpAmount} has been accepted.");
            DisplayAccountBalance();
        }

        
    }
}
