using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class DeclarationListProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static void _declarationList(this LL1Processor ll1)
        {
            ll1._declaration();
            var next = WordContainer.GetWordType();
            while (DeclarationProc.first.Contains(next))
            {
                ll1._declaration();
            }
        }
    }
}
