using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class DeclarationProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.INT,
            WordType.VOID
        };
        public static void _declaration(this LL1Processor ll1)
        {
            var offset = 2;
            switch (WordContainer.GetWordType(offset))
            {
                case WordType.SEMICOLON:
                    {
                        ll1._varDeclaration();
                        break;
                    }
                case WordType.BRACKET_L:
                    {
                        ll1._funDeclaration();
                        break;
                    }
                default:
                    {
                        throw new BNFException();
                    }
            }
        }
    }
}
