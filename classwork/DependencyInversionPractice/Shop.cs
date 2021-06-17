using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInversionPractice.Interfaces;

namespace DependencyInversionPractice
{
    public class Shop
    {
        private ILogger _logger;
        public Shop(ILogger logger)
        {
            _logger = logger;
        } 
        public void Buy(string itemName)
        {
            _logger.Write($"{itemName} has been bought."); 
        }

        public void StockUp(string itemName)
        {
            _logger.Write($"{itemName} has been replenished.");
        }
    }
}
