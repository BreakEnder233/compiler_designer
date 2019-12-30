using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ExpressionStmtProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.ID,
            WordType.BRACKET_L,
            WordType.NUM
        };

        public static GATNode _expressionStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            var next = WordContainer.GetWordType();
            while (ExpressionProc.first.Contains(next))
            {
                ll1._expression();
                next = WordContainer.GetWordType();
            }
            WordContainer.Advance(WordType.SEMICOLON);

            return node;
        }
        #region generators
        public static void ExpressionStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}

