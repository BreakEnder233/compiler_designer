using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class TermProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _term(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = Term;
            var factor1 = ll1._factor();
            node.AddChild(factor1);
            var next = WordContainer.GetWordType();
            while (next == WordType.MULOP)
            {
                var mulop = WordContainer.Advance(WordType.MULOP);
                node.AddChild(mulop);
                var factor2 = ll1._factor();
                node.AddChild(factor2);
                next = WordContainer.GetWordType();
            }
            return node;
        }
        #region generators
        public static void Term(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
