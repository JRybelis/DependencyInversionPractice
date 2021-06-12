using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPractice
{
    public class Shop
    {
        public void Buy(string itemName)
        {
            Console.WriteLine($"{itemName} has been bought.");
        }

        public void StockUp(string itemName)
        {
            Console.WriteLine($"Stock of {itemName} has been replenished.");
        }
    }
}
