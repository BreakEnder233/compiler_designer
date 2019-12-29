using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class FunDeclarationProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static void _funDeclaration(this LL1Processor ll1)
        {
            ll1._typeSpecifier();
            WordContainer.Advance(WordType.ID);
            WordContainer.Advance(WordType.BRACKET_L);
            ll1._params();
            WordContainer.Advance(WordType.BRACKET_R);
            ll1._compoundStmt();
        }
    }
}
