using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ReturnStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _returnStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            WordContainer.Advance(WordType.RETURN);
            var next = WordContainer.GetWordType();
            if (ExpressionProc.first.Contains(next))
            {
                ll1._expression();           
            }
            WordContainer.Advance(WordType.SEMICOLON);
            return node;
        }
        #region generators
        public static void ReturnStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
