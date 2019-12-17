using System;
using System.Collections.Generic;
using System.Text;
using LL1_compiler.Services.LLG_table;
namespace LL1_compiler.Services.Processor
{
    class Processor
    {
        private int step;
        private Stack<char> sym_stack = new Stack<char>();
        private string input_str;
        private string using_generate;
        private char cur_inputc;
        private LLtable table = new LLtable();

        public bool analyze(string obj_str)
        {
            step = 0;
            sym_stack.Push();

            return false;
        }
    }
}
