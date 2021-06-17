using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Loggers
{
    public class ConsoleLogger : IWriter, IReader, IClearer
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
