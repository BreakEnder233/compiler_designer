using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class IterationStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _iterationStmt(this LL1Processor ll1)
        {
            var node = new GATNode();

            WordContainer.Advance(WordType.WHILE);
            WordContainer.Advance(WordType.BRACKET_L);
            ll1._expression();
            WordContainer.Advance(WordType.BRACKET_R);
            ll1._statement();
       
            return node;
        }
        #region generators
        public static void IterationStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}