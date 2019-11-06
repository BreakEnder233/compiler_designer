using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using word_compiler.Services.Process;

namespace word_compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = Processor.WordAnalyse("int a = 1 + 2 * 3");
            foreach(var v in output)
            {
                Console.WriteLine($"<{v.type.ToString()} . {v.value}>");
            }
        }
    }
}
