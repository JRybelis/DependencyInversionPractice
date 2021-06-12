using System;

namespace DependencyInversionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            
            shop.Buy("Earplugs");

            Console.WriteLine("SOLID!");
        }
    }
}
