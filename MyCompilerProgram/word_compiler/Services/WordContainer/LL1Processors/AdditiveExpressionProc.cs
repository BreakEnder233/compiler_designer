using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class AdditiveExpressionProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _additiveExpression(this LL1Processor ll1)
        {
            var node = new GATNode();
            ll1._term();
            var next = WordContainer.GetWordType();
            while (next == WordType.ADDOP)
            {
                WordContainer.Advance(WordType.ADDOP);
                ll1._term();
                next = WordContainer.GetWordType();
            }
            return node;
        }

        #region generators
        public static void AdditiveExpression(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}