using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ProgramProc
    {
        public static void _program(this LL1Processor ll1)
        {
            ll1._declarationList();
            WordContainer.Advance(WordType.HASHTAG);
        }
    }
}
