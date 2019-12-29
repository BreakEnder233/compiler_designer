using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class VarDeclarationProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static void _varDeclaration(this LL1Processor ll1)
        {
            ll1._typeSpecifier();
            WordContainer.Advance(WordType.ID);
            WordContainer.Advance(WordType.SEMICOLON);
        }
    }
}
