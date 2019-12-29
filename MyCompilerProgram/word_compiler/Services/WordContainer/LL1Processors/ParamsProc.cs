using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ParamsProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static void _params(this LL1Processor ll1)
        {
            WordContainer.Advance(WordType.VOID);
        }
    }
}
