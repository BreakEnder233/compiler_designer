using System;
using System.Collections;
using LL1_compiler.Services.LLG_table;
namespace LL1_compiler
{
    class Program
    {

     
        static void Main(string[] args)
        {
            LLtable test = new LLtable();
            string testg = test.getGenerate('E','(');

            Console.WriteLine("testout: "+testg);
        }
    }
}
