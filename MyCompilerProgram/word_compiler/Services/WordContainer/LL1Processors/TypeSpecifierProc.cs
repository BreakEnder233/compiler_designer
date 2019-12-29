using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class TypeSpecifierProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static void _typeSpecifier(this LL1Processor ll1)
        {
            var next = WordContainer.GetWordType();
            switch (next)
            {
                case WordType.INT:
                    {
                        WordContainer.Advance();
                        break;
                    }
                case WordType.VOID:
                    {
                        WordContainer.Advance();
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
