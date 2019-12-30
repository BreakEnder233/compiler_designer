using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class CompoundStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _compoundStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            WordContainer.Advance(WordType.BRACE_L);
            ll1._localDeclarations();
            ll1._statementList();
            WordContainer.Advance(WordType.BRACE_R);
            return node;
        }
        #region generators
        public static void CompoundStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
