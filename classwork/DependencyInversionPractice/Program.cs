using System;
using DependencyInversionPractice.Interfaces;
using DependencyInversionPractice.Loggers;

namespace DependencyInversionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
;           
            var shop = new Shop(logger); 
            
            shop.Buy("Earplugs");

            Console.WriteLine("SOLID!");
        }
    }
}
