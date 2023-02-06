using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInversionPractice.Interfaces;

namespace DependencyInversionPractice.Loggers
{
    public class FileLogger : ILogger
    {
        public void Write(string input)
        {
            // File path:
            File.WriteAllText("/home/jokubas/dotNetProjects/dotNetSpecialisation/lesson5/classwork/DependencyInversionPractice/outputFile.txt", input);
        }
    }
}
