using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class CompoundStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static void _compoundStmt(this LL1Processor ll1)
        {
            WordContainer.Advance(WordType.BRACE_L);
            ll1._localDeclarations();
            ll1._statementList();
            WordContainer.Advance(WordType.BRACE_R);
        }
    }
}
