using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInversionPractice.Interfaces;

namespace DependencyInversionPractice.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}
